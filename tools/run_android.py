#!/usr/bin/env python3
"""Build, install, and launch every Lumina Playground app on a connected Android device."""

from __future__ import annotations

import argparse
import subprocess
import sys
import time
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]

APPS = [
    ("Market", "src/NuvyntraLabs.Lumina.Market/NuvyntraLabs.Lumina.Market.csproj", "com.nuvyntralabs.lumina.market"),
    ("Clinic", "src/NuvyntraLabs.Lumina.Clinic/NuvyntraLabs.Lumina.Clinic.csproj", "com.nuvyntralabs.lumina.clinic"),
    ("Field", "src/NuvyntraLabs.Lumina.Field/NuvyntraLabs.Lumina.Field.csproj", "com.nuvyntralabs.lumina.field"),
    ("Bank", "src/NuvyntraLabs.Lumina.Bank/NuvyntraLabs.Lumina.Bank.csproj", "com.nuvyntralabs.lumina.bank"),
    ("Civic", "src/NuvyntraLabs.Lumina.Civic/NuvyntraLabs.Lumina.Civic.csproj", "com.nuvyntralabs.lumina.civic"),
]


def run(cmd: list[str], cwd: Path | None = None) -> subprocess.CompletedProcess[str]:
    return subprocess.run(cmd, cwd=cwd, text=True, capture_output=True)


def adb(serial: str, *args: str) -> subprocess.CompletedProcess[str]:
    return run(["adb", "-s", serial, *args])


def build(csproj: Path) -> None:
    cmd = [
        "dotnet",
        "build",
        str(csproj),
        "-f",
        "net10.0-android",
        "-c",
        "Debug",
        "-p:RuntimeIdentifier=android-arm64",
        "-v",
        "q",
    ]
    proc = run(cmd, cwd=ROOT)
    if proc.returncode != 0:
        sys.stderr.write(proc.stdout)
        sys.stderr.write(proc.stderr)
        raise SystemExit(f"BUILD FAILED {csproj.name}")


def apk_path(csproj: Path) -> Path:
    root = csproj.parent / "bin" / "Debug" / "net10.0-android" / "android-arm64"
    signed = list(root.glob("*-Signed.apk"))
    if signed:
        return signed[0]
    apks = list(root.glob("*.apk"))
    if not apks:
        raise SystemExit(f"NO APK {root}")
    return apks[0]


def install_and_launch(serial: str, package: str, apk: Path) -> None:
    installed = adb(serial, "install", "--no-incremental", "-r", "-t", str(apk))
    if installed.returncode != 0:
        sys.stderr.write(installed.stdout)
        sys.stderr.write(installed.stderr)
        raise SystemExit(f"INSTALL FAILED {package}")

    resolve = adb(
        serial,
        "shell",
        "cmd",
        "package",
        "resolve-activity",
        "--brief",
        "-c",
        "android.intent.category.LAUNCHER",
        package,
    )
    activity = resolve.stdout.strip().splitlines()[-1]
    start = adb(serial, "shell", "am", "start", "-W", "-n", activity)
    if start.returncode != 0:
        sys.stderr.write(start.stdout)
        sys.stderr.write(start.stderr)
        raise SystemExit(f"LAUNCH FAILED {package}")
    time.sleep(2)
    pid = adb(serial, "shell", "pidof", package).stdout.strip()
    if not pid:
        raise SystemExit(f"APP NOT RUNNING {package}")
    print(f"OK {package} pid={pid.split()[0]} activity={activity}")


def first_device() -> str:
    devices = run(["adb", "devices"])
    for line in devices.stdout.splitlines()[1:]:
        parts = line.split()
        if len(parts) >= 2 and parts[1] == "device":
            return parts[0]
    raise SystemExit(f"No Android device connected.\n{devices.stdout}")


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--serial", default=None)
    parser.add_argument("--app", choices=[a[0].lower() for a in APPS] + ["all"], default="all")
    args = parser.parse_args()
    serial = args.serial or first_device()

    devices = run(["adb", "devices"])
    if serial not in devices.stdout:
        raise SystemExit(f"Device {serial} is not connected.\n{devices.stdout}")

    selected = APPS if args.app == "all" else [a for a in APPS if a[0].lower() == args.app]
    for name, rel, package in selected:
        csproj = ROOT / rel
        print(f"== {name} ==")
        build(csproj)
        install_and_launch(serial, package, apk_path(csproj))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
