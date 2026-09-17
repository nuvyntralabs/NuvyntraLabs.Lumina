#!/usr/bin/env python3
"""Rewrite each Lumina app onto its own product UI. No shared screen kit."""

from __future__ import annotations

import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1] / "src"

APPS = {
    "NuvyntraLabs.Lumina.Market": {
        "seed": "MarketSeed",
        "model": "MarketModel",
        "nav": "MarketNav",
        "ui": "MarketUi",
    },
    "NuvyntraLabs.Lumina.Clinic": {
        "seed": "ClinicSeed",
        "model": "ClinicModel",
        "nav": "ClinicNav",
        "ui": "ClinicUi",
    },
    "NuvyntraLabs.Lumina.Field": {
        "seed": "FieldSeed",
        "model": "FieldModel",
        "nav": "FieldNav",
        "ui": "FieldUi",
    },
    "NuvyntraLabs.Lumina.Bank": {
        "seed": "BankSeed",
        "model": "BankModel",
        "nav": "BankNav",
        "ui": "BankUi",
    },
    "NuvyntraLabs.Lumina.Civic": {
        "seed": "CivicSeed",
        "model": "CivicModel",
        "nav": "CivicNav",
        "ui": "CivicUi",
    },
}

TITLES = {
    "Walkthrough": "Welcome",
    "SignIn": "Welcome back",
    "SignUp": "Create your account",
    "ForgotPassword": "Forgot password",
    "ResetPassword": "New password",
    "ProfileSetup": "Your profile",
    "Home": "Home",
    "Dashboard": "Home",
    "Catalog": "Shop",
    "Categories": "All categories",
    "ProductDetail": "Cedar lounge chair",
    "Cart": "My cart",
    "Checkout": "Checkout",
    "PaymentResult": "Order placed",
    "Doctors": "Doctors near you",
    "DoctorProfile": "Dr. Priya Iyer",
    "Appointments": "My appointments",
    "InCall": "Video consult",
    "PinLock": "Enter PIN",
    "AppLock": "Unlock",
    "NfcScan": "Scan asset",
    "Jobs": "Job board",
    "JobDetail": "Job HF-204",
}


def humanize(name: str) -> str:
    if name in TITLES:
        return TITLES[name]
    parts = re.findall(r"[A-Z]+(?=[A-Z][a-z]|[0-9]|$)|[A-Z]?[a-z]+|[0-9]+", name)
    if not parts:
        return name
    return " ".join([parts[0].capitalize()] + [p.lower() if not p.isupper() else p for p in parts[1:]])


def method_for(app: str, page: str) -> str:
    if app.endswith("Market"):
        if page == "Walkthrough":
            return "Walkthrough"
        if page in {"SignIn", "SignUp", "ForgotPassword", "ResetPassword"}:
            return "Auth"
        if page == "Home":
            return "Home"
        if page in {"Catalog", "Categories", "Search", "Wishlist"}:
            return "Catalog"
        if page in {"ProductDetail", "Compare"}:
            return "Product"
        if page in {"Cart", "Orders"}:
            return "Cart"
        if page == "SellerChat":
            return "Chat"
        if page in {"Settings", "Help", "Subscription"}:
            return "Settings"
        if page == "PaymentResult":
            return "Result"
        if page in {"Checkout", "CardPayment", "Filters", "Addresses", "ProfileSetup", "SavedCards"}:
            return "Form"
        return "List"
    if app.endswith("Clinic"):
        if page == "Walkthrough":
            return "Walkthrough"
        if page == "SignIn":
            return "Auth"
        if page == "Home":
            return "Home"
        if page == "Doctors":
            return "Doctors"
        if page == "DoctorProfile":
            return "Profile"
        if page in {"Conversation", "Inbox"}:
            return "Chat"
        if page == "InCall":
            return "Call"
        if page in {"Settings", "Help", "Faq"}:
            return "Settings"
        if page in {"Booking", "Insurance", "Vitals", "Documents", "HealthProfile"}:
            return "Form"
        return "List"
    if app.endswith("Bank"):
        if page in {"SignIn", "Kyc"}:
            return "Auth"
        if page in {"PinLock", "AppLock"}:
            return "Lock"
        if page == "Dashboard":
            return "Dashboard"
        if page == "Accounts":
            return "Accounts"
        if page in {"Cards", "CardDetail"}:
            return "Cards"
        if page in {"Settings", "Support"}:
            return "Settings"
        if page in {"Transfer", "Invoice"}:
            return "Form"
        if page.endswith("Detail"):
            return "Detail"
        return "List"
    if app.endswith("Field"):
        if page == "SignIn":
            return "Auth"
        if page == "Home":
            return "Home"
        if page == "Jobs":
            return "Jobs"
        if page in {"JobDetail", "AssetDetail"}:
            return "Job"
        if page == "NfcScan":
            return "Scan"
        if page in {"Settings"}:
            return "Settings"
        if page in {"Inspection", "Checklist", "Evidence", "Timesheet"}:
            return "Form"
        return "List"
    if page == "SignIn":
        return "Auth"
    if page == "Home":
        return "Home"
    if page == "Services":
        return "Services"
    if page == "Transit":
        return "Transit"
    if page in {"Settings", "About", "WhatsNew", "Help", "Faq"}:
        return "Settings"
    if page in {"Booking", "Contact"}:
        return "Form"
    if page.endswith("Detail"):
        return "Detail"
    return "List"


def parse(text: str) -> dict | None:
    cls = re.search(r"public sealed class (\w+)Page", text)
    vm = re.search(r"public \w+Page\((\w+) vm\)", text)
    if not (cls and vm):
        return None
    body = re.search(r'Subtitle = "([^"]*)"', text)
    actions = re.findall(r'new\("([^"]+)", vm\.(\w+), (true|false)\)', text)
    if not actions:
        actions = re.findall(r'AddAction\("([^"]+)", vm\.(\w+)', text)
        actions = [(a[0], a[1], "false") for a in actions]
    return {
        "page": cls.group(1),
        "vm": vm.group(1),
        "body": body.group(1) if body else "",
        "actions": actions,
    }


def emit(ns: str, cfg: dict, info: dict) -> str:
    page = info["page"]
    method = method_for(ns, page)
    extra = ""
    if ns.endswith("Market") and method == "Home":
        extra = "\n            Aisles = SeedRows.For(MarketSeed.Items, \"Categories\"),"
    actions = ",\n".join(
        f'            new {cfg["nav"]}("{lab}", vm.{cmd}, {prim})' for lab, cmd, prim in info["actions"]
    ) or ""
    action_init = f"[\n{actions}\n        ]" if actions else "[]"
    title = humanize(page)
    return f"""using NuvyntraLabs.Lumina.Core;

namespace {ns};

public sealed class {page}Page : ContentPage
{{
    public {page}Page({info['vm']} vm)
    {{
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "{title}";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = {cfg['ui']}.{method}(new {cfg['model']}
        {{
            Title = "{title}",
            Subtitle = "{info['body']}",
            Items = SeedRows.For({cfg['seed']}.Items, "{page}"),{extra}
            Actions = {action_init}
        }});
    }}
}}
"""


def main() -> None:
    n = 0
    for folder, cfg in APPS.items():
        pages = ROOT / folder / "Pages"
        for path in sorted(pages.glob("*Page.cs")):
            if path.name == "LuminaPage.cs":
                path.unlink()
                continue
            info = parse(path.read_text())
            if info is None:
                print("skip", path)
                continue
            path.write_text(emit(folder, cfg, info))
            n += 1
    print(f"rewrote {n} independent pages")


if __name__ == "__main__":
    main()
