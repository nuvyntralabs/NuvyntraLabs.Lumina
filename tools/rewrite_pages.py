#!/usr/bin/env python3
"""Rewrite Lumina pages to product ScreenKit layouts."""

from __future__ import annotations

import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1] / "src"

APPS = {
    "NuvyntraLabs.Lumina.Market": ("Market", "MarketSeed", "Harbour Market"),
    "NuvyntraLabs.Lumina.Clinic": ("Clinic", "ClinicSeed", "Nuvexa Clinic"),
    "NuvyntraLabs.Lumina.Field": ("Field", "FieldSeed", "Harbor Field"),
    "NuvyntraLabs.Lumina.Bank": ("Bank", "BankSeed", "Aether Bank"),
    "NuvyntraLabs.Lumina.Civic": ("Civic", "CivicSeed", "Civic Pulse"),
}

HEADINGS = {
    "Walkthrough": "Welcome",
    "SignIn": "Welcome back",
    "SignUp": "Create your account",
    "ForgotPassword": "Forgot password",
    "ResetPassword": "Choose a password",
    "ProfileSetup": "A little about you",
    "Home": "Good afternoon",
    "Dashboard": "Good afternoon",
    "PaymentResult": "You're all set",
    "PinLock": "Enter your PIN",
    "AppLock": "Welcome back",
    "InCall": "On a call",
    "NfcScan": "Ready to scan",
    "SellerChat": "Harbour Kitchen",
    "Conversation": "Dr. Iyer",
    "Settings": "You",
}

CHROME = {
    "SignIn": "Sign in",
    "SignUp": "Create account",
    "ForgotPassword": "Forgot password",
    "ResetPassword": "New password",
    "ProfileSetup": "Profile",
    "Walkthrough": "Welcome",
    "ProductDetail": "Product",
    "OrderDetail": "Order",
    "CardPayment": "Pay",
    "SavedCards": "Cards",
    "PaymentResult": "Paid",
    "StoreLocator": "Stores",
    "SellerChat": "Kitchen",
    "LabResults": "Labs",
    "LabDetail": "Result",
    "DoctorProfile": "Doctor",
    "PharmacyDetail": "Pharmacy",
    "HealthProfile": "Health",
    "VisitDetail": "Visit",
    "JobDetail": "Job",
    "AssetDetail": "Asset",
    "AccountDetail": "Account",
    "BillDetail": "Bill",
    "CardDetail": "Card",
    "LoanDetail": "Loan",
    "InvestDetail": "Holding",
    "PermitDetail": "Permit",
    "ArticleDetail": "Story",
    "RequestDetail": "Request",
    "TicketDetail": "Ticket",
    "EventDetail": "Event",
    "OfflineQueue": "Queue",
    "PinLock": "Unlock",
    "AppLock": "Locked",
    "InCall": "Call",
    "NfcScan": "Scan",
    "Timesheet": "Time",
    "WhatsNew": "What's new",
    "Kyc": "Verify",
}

ACTION_LABELS = {
    "SignIn": "Sign in",
    "SignUp": "Create account",
    "ForgotPassword": "Forgot password?",
    "ResetPassword": "Save password",
    "ProfileSetup": "Save profile",
    "Home": "Continue",
    "Dashboard": "Continue",
    "Categories": "Aisles",
    "Catalog": "Shop",
    "Search": "Search",
    "Cart": "Cart",
    "Orders": "Orders",
    "Notifications": "Alerts",
    "Settings": "You",
    "ProductDetail": "View item",
    "Compare": "Compare",
    "Filters": "Filters",
    "Wishlist": "Saved",
    "Checkout": "Checkout",
    "CardPayment": "Pay now",
    "SavedCards": "Use a saved card",
    "PaymentResult": "Done",
    "OrderDetail": "View order",
    "Tracking": "Track order",
    "Invoice": "Invoice",
    "Receipt": "Receipt",
    "Reviews": "Reviews",
    "StoreLocator": "Find a store",
    "Addresses": "Change address",
    "Subscription": "Membership",
    "SellerChat": "Message kitchen",
    "Help": "Help",
    "Continue": "Continue",
    "Appointments": "Visits",
    "Doctors": "Doctors",
    "Pharmacy": "Pharmacy",
    "LabResults": "Labs",
    "Inbox": "Inbox",
    "InCall": "Join call",
    "Conversation": "Open thread",
    "Jobs": "Jobs",
    "Sites": "Sites",
    "Assets": "Assets",
    "OfflineQueue": "Queue",
    "Accounts": "Accounts",
    "Cards": "Cards",
    "Transfer": "Send",
    "Invest": "Invest",
    "Services": "Services",
    "Transit": "Transit",
    "Events": "Events",
    "News": "News",
    "Wallet": "Wallet",
    "PinLock": "Unlock",
    "AssetDetail": "Open asset",
}

AUTH = {
    "Walkthrough",
    "SignIn",
    "SignUp",
    "ForgotPassword",
    "ResetPassword",
    "ProfileSetup",
    "Kyc",
}
HOME = {"Home", "Dashboard"}
CHAT = {"SellerChat", "Conversation", "Inbox", "Support"}
SETTINGS = {"Settings", "About", "WhatsNew"}
LOCK = {"PinLock", "AppLock"}
RESULT = {"PaymentResult"}
CALL = {"InCall"}
SCAN = {"NfcScan"}
FORM = {
    "Checkout",
    "CardPayment",
    "Filters",
    "Booking",
    "Transfer",
    "Vitals",
    "Insurance",
    "Documents",
    "Checklist",
    "Evidence",
    "Timesheet",
    "Contact",
    "Invoice",
    "Receipt",
    "Statements",
}


def humanize(name: str) -> str:
    if name in CHROME:
        return CHROME[name]
    parts = re.findall(r"[A-Z]+(?=[A-Z][a-z]|[0-9]|$)|[A-Z]?[a-z]+|[0-9]+", name)
    if not parts:
        return name
    words = [parts[0].capitalize()] + [p.lower() if not p.isupper() else p for p in parts[1:]]
    return " ".join(words)


def action_label(dest: str) -> str:
    return ACTION_LABELS.get(dest, humanize(dest))


def kind_of(name: str) -> str:
    if name == "Walkthrough":
        return "Walkthrough"
    if name in AUTH:
        return "Auth"
    if name in HOME:
        return "Home"
    if name in CHAT:
        return "Chat"
    if name in SETTINGS:
        return "Settings"
    if name in LOCK:
        return "Lock"
    if name in RESULT:
        return "Result"
    if name in CALL:
        return "Call"
    if name in SCAN:
        return "Scan"
    if name in FORM or name.endswith("Payment"):
        return "Form"
    if name.endswith("Detail") or name.endswith("Profile") or name in {
        "Tracking",
        "Inspection",
        "Route",
    }:
        return "Detail"
    return "List"


def parse_page(text: str) -> dict | None:
    cls = re.search(r"public sealed class (\w+)Page", text)
    vm = re.search(r"public \w+Page\((\w+) vm\)", text)
    base = re.search(r': base\("([^"]+)", "([^"]+)", "([^"]+)"\)', text)
    seed = re.search(r"(\w+Seed)\.Items", text)
    if not (cls and vm and base and seed):
        return None
    actions = re.findall(r'AddAction\("([^"]+)", vm\.(\w+)', text)
    dests = []
    for label, command in actions:
        dest = command
        if dest.startswith("Open") and dest.endswith("Command"):
            dest = dest[4:-7]
        elif dest.endswith("Command"):
            dest = dest[:-7]
        dests.append((action_label(dest if dest != "Continue" else label), command, dest))
    return {
        "page": cls.group(1),
        "vm": vm.group(1),
        "title": base.group(1),
        "kicker": base.group(2),
        "body": base.group(3),
        "seed": seed.group(1),
        "actions": dests,
    }


def emit(ns: str, app_name: str, seed: str, info: dict) -> str:
    name = info["page"]
    kind = kind_of(name)
    chrome = humanize(name)
    heading = HEADINGS.get(name, humanize(name))
    actions = []
    for i, (label, command, _dest) in enumerate(info["actions"]):
        primary = "true" if i == 0 else "false"
        actions.append(f'            new("{label}", vm.{command}, {primary})')
    action_block = ",\n".join(actions) if actions else ""
    action_init = f"[\n{action_block}\n        ]" if actions else "[]"
    return f"""using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.Lumina.Ui;

namespace {ns};

public sealed class {name}Page : LuminaPage
{{
    public {name}Page({info['vm']} vm)
        : base(new ScreenRequest
        {{
            Kind = ScreenKind.{kind},
            ChromeTitle = "{escape(chrome)}",
            Title = "{escape(heading)}",
            AppName = "{escape(app_name)}",
            Subtitle = "{escape(info['body'])}",
            Items = SeedRows.For({seed}.Items, "{name}"),
            Actions = {action_init}
        }})
    {{
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
    }}
}}
"""


def escape(value: str) -> str:
    return value.replace("\\", "\\\\").replace('"', '\\"')


def main() -> None:
    count = 0
    for folder, (ns_tail, seed, app_name) in APPS.items():
        ns = folder
        pages = ROOT / folder / "Pages"
        lumina = pages / "LuminaPage.cs"
        if lumina.exists():
            lumina.unlink()
        for path in sorted(pages.glob("*Page.cs")):
            if path.name == "LuminaPage.cs":
                continue
            info = parse_page(path.read_text())
            if info is None:
                print(f"skip {path}")
                continue
            path.write_text(emit(ns, app_name, seed, info))
            count += 1
    print(f"rewrote {count} pages")


if __name__ == "__main__":
    main()
