using Microsoft.Extensions.Logging;
using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;
using Plugin.Maui.FeatureFlags;
using Plugin.Maui.FormValidation;
using Plugin.Maui.HttpForge;
using Plugin.Maui.LocalStore;
using Plugin.Maui.MVVMExpress.Auth;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseNuvyntraUIKit()
            .UseMauiFormValidation(o =>
            {
                o.Trigger = ValidationTrigger.LostFocus;
                o.ShowMessage = true;
            })
            .UseMauiFeatureFlags(o =>
            {
                o.Environment = FeatureFlagEnvironment.Development;
                o.LocalFlags["new_checkout"] = true;
                o.LocalFlags["telehealth"] = true;
                o.LocalFlags["offline_first"] = true;
            })
            .UseMauiLocalStore(o =>
            {
                o.Backend = StoreBackend.Nuvexa;
                o.Path = Path.Combine(FileSystem.AppDataDirectory, "lumina-field.nvx");
                o.CreateIfMissing = true;
            })
            .UseHttpForge()
            .UseMvvmExpress(o => o
                .UseNavigationPage((nav, _) => nav
                    .Map<SignInViewModel, SignInPage>("signin")
                    .Map<HomeViewModel, HomePage>("home")
                    .Map<JobsViewModel, JobsPage>("jobs")
                    .Map<JobDetailViewModel, JobDetailPage>("jobdetail")
                    .Map<SitesViewModel, SitesPage>("sites")
                    .Map<GeofencesViewModel, GeofencesPage>("geofences")
                    .Map<InspectionViewModel, InspectionPage>("inspection")
                    .Map<EvidenceViewModel, EvidencePage>("evidence")
                    .Map<NfcScanViewModel, NfcScanPage>("nfcscan")
                    .Map<AssetsViewModel, AssetsPage>("assets")
                    .Map<AssetDetailViewModel, AssetDetailPage>("assetdetail")
                    .Map<ConflictsViewModel, ConflictsPage>("conflicts")
                    .Map<OfflineQueueViewModel, OfflineQueuePage>("offlinequeue")
                    .Map<PrintersViewModel, PrintersPage>("printers")
                    .Map<ReceiptViewModel, ReceiptPage>("receipt")
                    .Map<TimesheetViewModel, TimesheetPage>("timesheet")
                    .Map<DashboardViewModel, DashboardPage>("dashboard")
                    .Map<FilesViewModel, FilesPage>("files")
                    .Map<ChecklistViewModel, ChecklistPage>("checklist")
                    .Map<SafetyViewModel, SafetyPage>("safety")
                    .Map<RouteViewModel, RoutePage>("route")
                    .Map<TeamViewModel, TeamPage>("team")
                    .Map<NotificationsViewModel, NotificationsPage>("notifications")
                    .Map<SettingsViewModel, SettingsPage>("settings"))
                .UseDialogs()
                .UseAuth<SignInViewModel>());

        builder.Services.AddSingleton<IAuthState, DemoAuthState>();
        builder.Services.AddSingleton<IFieldApi, FieldApi>();
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignInPage>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<JobsViewModel>();
        builder.Services.AddTransient<JobsPage>();
        builder.Services.AddTransient<JobDetailViewModel>();
        builder.Services.AddTransient<JobDetailPage>();
        builder.Services.AddTransient<SitesViewModel>();
        builder.Services.AddTransient<SitesPage>();
        builder.Services.AddTransient<GeofencesViewModel>();
        builder.Services.AddTransient<GeofencesPage>();
        builder.Services.AddTransient<InspectionViewModel>();
        builder.Services.AddTransient<InspectionPage>();
        builder.Services.AddTransient<EvidenceViewModel>();
        builder.Services.AddTransient<EvidencePage>();
        builder.Services.AddTransient<NfcScanViewModel>();
        builder.Services.AddTransient<NfcScanPage>();
        builder.Services.AddTransient<AssetsViewModel>();
        builder.Services.AddTransient<AssetsPage>();
        builder.Services.AddTransient<AssetDetailViewModel>();
        builder.Services.AddTransient<AssetDetailPage>();
        builder.Services.AddTransient<ConflictsViewModel>();
        builder.Services.AddTransient<ConflictsPage>();
        builder.Services.AddTransient<OfflineQueueViewModel>();
        builder.Services.AddTransient<OfflineQueuePage>();
        builder.Services.AddTransient<PrintersViewModel>();
        builder.Services.AddTransient<PrintersPage>();
        builder.Services.AddTransient<ReceiptViewModel>();
        builder.Services.AddTransient<ReceiptPage>();
        builder.Services.AddTransient<TimesheetViewModel>();
        builder.Services.AddTransient<TimesheetPage>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<FilesViewModel>();
        builder.Services.AddTransient<FilesPage>();
        builder.Services.AddTransient<ChecklistViewModel>();
        builder.Services.AddTransient<ChecklistPage>();
        builder.Services.AddTransient<SafetyViewModel>();
        builder.Services.AddTransient<SafetyPage>();
        builder.Services.AddTransient<RouteViewModel>();
        builder.Services.AddTransient<RoutePage>();
        builder.Services.AddTransient<TeamViewModel>();
        builder.Services.AddTransient<TeamPage>();
        builder.Services.AddTransient<NotificationsViewModel>();
        builder.Services.AddTransient<NotificationsPage>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<SettingsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
