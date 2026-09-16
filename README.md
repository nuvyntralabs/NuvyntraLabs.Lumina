# NuvyntraLabs.Lumina

Five standalone .NET MAUI prototypes in one hub submodule. Lumina UI, MVVMExpress navigation, HttpForge contracts, NuvexaDB via LocalStore. Static seed — no live backends.

## Apps

- **Lumina Market** (`src/NuvyntraLabs.Lumina.Market`) — Retail, grocery, and food — warm paper, aurora accent. · 32 screens
- **Nuvexa Clinic** (`src/NuvyntraLabs.Lumina.Clinic`) — Appointments, pharmacy, labs, and a quiet in-call room. · 27 screens
- **Harbor Field** (`src/NuvyntraLabs.Lumina.Field`) — Jobs, inspections, NFC assets, and an offline queue. · 24 screens
- **Aether Bank** (`src/NuvyntraLabs.Lumina.Bank`) — Accounts, cards, wealth, and a lock that actually locks. · 24 screens
- **Civic Pulse** (`src/NuvyntraLabs.Lumina.Civic`) — City services, transit, events, and a civic wallet. · 23 screens

**130 screens** across the five heads.

## Run

```bash
dotnet build src/NuvyntraLabs.Lumina.Market/NuvyntraLabs.Lumina.Market.csproj -f net10.0-maccatalyst
```

Demo password on every sign-in screen: `secret`.

## Stack

- [NuvyntraLabs.UIKit](https://www.nuget.org/packages/NuvyntraLabs.UIKit) 1.4.0
- [Plugin.Maui.MVVMExpress](https://www.nuget.org/packages/Plugin.Maui.MVVMExpress) 1.3.0
- [Plugin.Maui.HttpForge](https://www.nuget.org/packages/Plugin.Maui.HttpForge) 1.1.1
- [Plugin.Maui.LocalStore](https://www.nuget.org/packages/Plugin.Maui.LocalStore) 1.1.0 + [Nuventra.NuvexaDB](https://www.nuget.org/packages/Nuventra.NuvexaDB)
- [Plugin.Maui.FormValidation](https://www.nuget.org/packages/Plugin.Maui.FormValidation) 1.0.4
- [Plugin.Maui.FeatureFlags](https://www.nuget.org/packages/Plugin.Maui.FeatureFlags) 1.0.9

Niladri Padhy / Nuvyntra Labs. MIT.
