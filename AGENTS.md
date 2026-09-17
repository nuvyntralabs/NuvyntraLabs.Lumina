# Lumina Playground — AI Coding Agent Guide

Nuvexa mobile prototyping hub: five standalone MAUI apps (Market, Clinic, Field, Bank, Civic) plus `NuvyntraLabs.Lumina.Core`.

- Hub folder: `LuminaPlayground/`
- GitHub: https://github.com/nuvyntralabs/NuvyntraLabs.Lumina
- UI: `NuvyntraLabs.UIKit` (`NV*` + Lumina tokens). Do not add Syncfusion / Telerik / CommunityToolkit.Mvvm.
- Navigation: `Plugin.Maui.MVVMExpress` NavigationPage maps. ViewModels never call `Shell.Current`.
- Data: HttpForge interfaces implemented by in-memory seed; LocalStore opens a Nuvexa `.nvx` on first launch.
- Publishing: this is an app, not a nupkg. Never `dotnet nuget push`.
- Beautify one head at a time. Bank is the reference chrome (tabs, icons, pay hub, more menu).
