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

namespace NuvyntraLabs.Lumina.Clinic;

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
                o.Path = Path.Combine(FileSystem.AppDataDirectory, "lumina-clinic.nvx");
                o.CreateIfMissing = true;
            })
            .UseHttpForge()
            .UseMvvmExpress(o => o
                .UseNavigationPage((nav, _) => nav
                    .Map<WalkthroughViewModel, WalkthroughPage>("walkthrough")
                    .Map<SignInViewModel, SignInPage>("signin")
                    .Map<HealthProfileViewModel, HealthProfilePage>("healthprofile")
                    .Map<HomeViewModel, HomePage>("home")
                    .Map<AppointmentsViewModel, AppointmentsPage>("appointments")
                    .Map<BookingViewModel, BookingPage>("booking")
                    .Map<DoctorsViewModel, DoctorsPage>("doctors")
                    .Map<DoctorProfileViewModel, DoctorProfilePage>("doctorprofile")
                    .Map<VisitDetailViewModel, VisitDetailPage>("visitdetail")
                    .Map<PrescriptionsViewModel, PrescriptionsPage>("prescriptions")
                    .Map<PharmacyViewModel, PharmacyPage>("pharmacy")
                    .Map<PharmacyDetailViewModel, PharmacyDetailPage>("pharmacydetail")
                    .Map<LabResultsViewModel, LabResultsPage>("labresults")
                    .Map<LabDetailViewModel, LabDetailPage>("labdetail")
                    .Map<DocumentsViewModel, DocumentsPage>("documents")
                    .Map<InvoiceViewModel, InvoicePage>("invoice")
                    .Map<InboxViewModel, InboxPage>("inbox")
                    .Map<ConversationViewModel, ConversationPage>("conversation")
                    .Map<InCallViewModel, InCallPage>("incall")
                    .Map<InsuranceViewModel, InsurancePage>("insurance")
                    .Map<DepartmentsViewModel, DepartmentsPage>("departments")
                    .Map<VitalsViewModel, VitalsPage>("vitals")
                    .Map<MedicationsViewModel, MedicationsPage>("medications")
                    .Map<FaqViewModel, FaqPage>("faq")
                    .Map<HelpViewModel, HelpPage>("help")
                    .Map<NotificationsViewModel, NotificationsPage>("notifications")
                    .Map<SettingsViewModel, SettingsPage>("settings"))
                .UseDialogs()
                .UseAuth<SignInViewModel>());

        builder.Services.AddSingleton<IAuthState, DemoAuthState>();
        builder.Services.AddSingleton<IClinicApi, ClinicApi>();
        builder.Services.AddTransient<WalkthroughViewModel>();
        builder.Services.AddTransient<WalkthroughPage>();
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignInPage>();
        builder.Services.AddTransient<HealthProfileViewModel>();
        builder.Services.AddTransient<HealthProfilePage>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<AppointmentsViewModel>();
        builder.Services.AddTransient<AppointmentsPage>();
        builder.Services.AddTransient<BookingViewModel>();
        builder.Services.AddTransient<BookingPage>();
        builder.Services.AddTransient<DoctorsViewModel>();
        builder.Services.AddTransient<DoctorsPage>();
        builder.Services.AddTransient<DoctorProfileViewModel>();
        builder.Services.AddTransient<DoctorProfilePage>();
        builder.Services.AddTransient<VisitDetailViewModel>();
        builder.Services.AddTransient<VisitDetailPage>();
        builder.Services.AddTransient<PrescriptionsViewModel>();
        builder.Services.AddTransient<PrescriptionsPage>();
        builder.Services.AddTransient<PharmacyViewModel>();
        builder.Services.AddTransient<PharmacyPage>();
        builder.Services.AddTransient<PharmacyDetailViewModel>();
        builder.Services.AddTransient<PharmacyDetailPage>();
        builder.Services.AddTransient<LabResultsViewModel>();
        builder.Services.AddTransient<LabResultsPage>();
        builder.Services.AddTransient<LabDetailViewModel>();
        builder.Services.AddTransient<LabDetailPage>();
        builder.Services.AddTransient<DocumentsViewModel>();
        builder.Services.AddTransient<DocumentsPage>();
        builder.Services.AddTransient<InvoiceViewModel>();
        builder.Services.AddTransient<InvoicePage>();
        builder.Services.AddTransient<InboxViewModel>();
        builder.Services.AddTransient<InboxPage>();
        builder.Services.AddTransient<ConversationViewModel>();
        builder.Services.AddTransient<ConversationPage>();
        builder.Services.AddTransient<InCallViewModel>();
        builder.Services.AddTransient<InCallPage>();
        builder.Services.AddTransient<InsuranceViewModel>();
        builder.Services.AddTransient<InsurancePage>();
        builder.Services.AddTransient<DepartmentsViewModel>();
        builder.Services.AddTransient<DepartmentsPage>();
        builder.Services.AddTransient<VitalsViewModel>();
        builder.Services.AddTransient<VitalsPage>();
        builder.Services.AddTransient<MedicationsViewModel>();
        builder.Services.AddTransient<MedicationsPage>();
        builder.Services.AddTransient<FaqViewModel>();
        builder.Services.AddTransient<FaqPage>();
        builder.Services.AddTransient<HelpViewModel>();
        builder.Services.AddTransient<HelpPage>();
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
