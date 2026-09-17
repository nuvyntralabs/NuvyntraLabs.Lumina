# Lumina Playground

Five standalone .NET MAUI apps that show what the **Nuvexa Dev Ecosystem** can ship in a weekend: Lumina UI, MVVMExpress navigation, HttpForge contracts, and NuvexaDB via LocalStore. Static seed — no live backends.

Hub folder: `LuminaPlayground/`  
GitHub: [nuvyntralabs/NuvyntraLabs.LuminaPlayground](https://github.com/nuvyntralabs/NuvyntraLabs.LuminaPlayground)

**130 screens** across five product heads. Same stack. Five different businesses.

## Five apps

Each app is a complete head you can build, install, and walk. Demo password on every sign-in screen: `secret`.

### 1. Lumina Market — `src/NuvyntraLabs.Lumina.Market`

Retail, grocery, and food on warm paper with an aurora accent. · **32 screens**

Walk a store from walkthrough to receipt: aisles, catalog, compare, same-day slots, kitchen tab, courier tracking, and a weekly produce crate. Built to prove a commerce surface can stay on Lumina tokens instead of a vendor UI kit.

Highlights: catalog and filters, checkout and saved cards, order tracking, seller chat, store locator.

### 2. Nuvexa Clinic — `src/NuvyntraLabs.Lumina.Clinic`

Appointments, pharmacy, labs, and a quiet in-call room. · **27 screens**

A Harbour clinic day: book Dr. Iyer, read a lipid panel, pick up a statin, and sit in a video room. Care records, scripts, and invoices live in one file — the same LocalStore / NuvexaDB seed every other head uses.

Highlights: booking and clinician directory, pharmacy counter, lab detail, documents, in-call chrome, vitals.

### 3. Harbor Field — `src/NuvyntraLabs.Lumina.Field`

Jobs, inspections, NFC assets, and an offline queue. · **24 screens**

A van-tablet day in the Harbour district. Inspect a storm pump, write an NFC tag, queue photos until the radio comes back, print a Zebra receipt, and resolve a local-vs-desk conflict. This is the head that shows field work without a live sync server.

Highlights: job board and SLA, geofences, NFC asset register, offline queue, thermal receipt, safety permit.

### 4. Aether Bank — `src/NuvyntraLabs.Lumina.Bank`

Retail banking: accounts, cards, pay, wealth, lock. · **24 screens**

Ada’s sterling books, an aurora debit, a frozen travel card, and a PIN that actually gates the dashboard after background. Wealth sleeves and KYC sit next to bills and international payees — a serious-looking bank on the same MVVMExpress maps as Market.

Highlights: accounts and statements, cards and freeze, transfer and bills, invest, app lock / Face ID chrome.

### 5. Civic Pulse — `src/NuvyntraLabs.Lumina.Civic`

City services, transit, events, and a civic wallet. · **23 screens**

Harbour borough today: bin day, Bus 12, a night market, a missed-waste request, and a day-rover QR in the wallet. Councils, libraries, and permits share one resident pass.

Highlights: 311-style requests, live-looking transit, events and news, civic wallet, visitor-bay permit.

## Why the Nuvexa Dev Ecosystem

Lumina Playground is not a theme pack. It is five products on one open stack from [Nuvyntra Labs](https://nuvyntralabs.github.io/) (Niladri Prasad Padhy / MauiEssentials). You pick the pieces you need; you do not pull a monolith.

| Advantage | What you get |
| --- | --- |
| **One visual language** | [NuvyntraLabs.UIKit](https://www.nuget.org/packages/NuvyntraLabs.UIKit) — Lumina `NV*` controls and page recipes. Five verticals, one paper. |
| **Navigation you can finish** | [Plugin.Maui.MVVMExpress](https://www.nuget.org/packages/Plugin.Maui.MVVMExpress) — ViewModels, async state, NavigationPage maps, dialogs. No `Shell.Current` from a ViewModel. |
| **Typed APIs without a backend** | [Plugin.Maui.HttpForge](https://www.nuget.org/packages/Plugin.Maui.HttpForge) contracts backed by in-memory seed. Swap the implementation when a real host exists. |
| **Documents that travel** | [Plugin.Maui.LocalStore](https://www.nuget.org/packages/Plugin.Maui.LocalStore) + [Nuventra.NuvexaDB](https://www.nuget.org/packages/Nuventra.NuvexaDB) — Room-style access over one portable `.nvx` file. |
| **Forms and flags** | [Plugin.Maui.FormValidation](https://www.nuget.org/packages/Plugin.Maui.FormValidation) and [Plugin.Maui.FeatureFlags](https://www.nuget.org/packages/Plugin.Maui.FeatureFlags) on the same heads that already have UI and data. |
| **Compose, do not replace** | Need GPS, NFC, offline jobs, TLS pin, or print later? Take the matching [MauiEssentials](https://github.com/nuvyntralabs/MauiEssentials) plugin. Field already sketches that path (NFC, queue, receipt). |
| **MIT and pipeline-published** | Packages ship from each repo’s GitHub Actions. The playground is an app, not a nupkg — run a head, do not pack it. |

Usual alternatives stay .NET MAUI built-ins, CommunityToolkit.Maui, Syncfusion / Telerik for controls, Refit for HTTP, and SQLite / LiteDB / Realm for local data. Use Nuvexa when you want Lumina + focused plugins + an embedded `.nvx` in one ecosystem.

## Stay tuned

Lots of new ideas are in the pipeline — more heads, deeper plugin wiring, and sharper Lumina recipes. **Stay tuned for more exciting features.**

## Run

Android (connected `arm64` device):

```bash
python3 tools/run_android.py
python3 tools/run_android.py --app clinic
```

```bash
dotnet build src/NuvyntraLabs.Lumina.Bank/NuvyntraLabs.Lumina.Bank.csproj -f net10.0-android -p:RuntimeIdentifier=android-arm64
```

```bash
dotnet build src/NuvyntraLabs.Lumina.Market/NuvyntraLabs.Lumina.Market.csproj -f net10.0-maccatalyst
```

## Stack

- [NuvyntraLabs.UIKit](https://www.nuget.org/packages/NuvyntraLabs.UIKit) 1.4.0
- [Plugin.Maui.MVVMExpress](https://www.nuget.org/packages/Plugin.Maui.MVVMExpress) 1.3.0
- [Plugin.Maui.HttpForge](https://www.nuget.org/packages/Plugin.Maui.HttpForge) 1.1.1
- [Plugin.Maui.LocalStore](https://www.nuget.org/packages/Plugin.Maui.LocalStore) 1.1.0 + [Nuventra.NuvexaDB](https://www.nuget.org/packages/Nuventra.NuvexaDB)
- [Plugin.Maui.FormValidation](https://www.nuget.org/packages/Plugin.Maui.FormValidation) 1.0.4
- [Plugin.Maui.FeatureFlags](https://www.nuget.org/packages/Plugin.Maui.FeatureFlags) 1.0.9

Niladri Padhy / Nuvyntra Labs. MIT.
