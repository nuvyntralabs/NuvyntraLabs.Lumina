# NuvyntraLabs.Lumina — AI Coding Agent Guide

Five standalone MAUI apps (Market, Clinic, Field, Bank, Civic) plus `NuvyntraLabs.Lumina.Core`.

- Hub folder: `Lumina/`
- GitHub: https://github.com/nuvyntralabs/NuvyntraLabs.Lumina
- UI: `NuvyntraLabs.UIKit` (`NV*` + Lumina tokens). Do not add Syncfusion / Telerik / CommunityToolkit.Mvvm.
- Navigation: `Plugin.Maui.MVVMExpress` NavigationPage maps. ViewModels never call `Shell.Current`.
- Data: HttpForge interfaces implemented by in-memory seed; LocalStore opens a Nuvexa `.nvx` on first launch.
- Publishing: this is an app, not a nupkg. Never `dotnet nuget push`.
