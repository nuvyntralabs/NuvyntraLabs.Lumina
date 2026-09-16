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

namespace NuvyntraLabs.Lumina.Civic;

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
                o.Path = Path.Combine(FileSystem.AppDataDirectory, "lumina-civic.nvx");
                o.CreateIfMissing = true;
            })
            .UseHttpForge()
            .UseMvvmExpress(o => o
                .UseNavigationPage((nav, _) => nav
                    .Map<SignInViewModel, SignInPage>("signin")
                    .Map<HomeViewModel, HomePage>("home")
                    .Map<ServicesViewModel, ServicesPage>("services")
                    .Map<RequestDetailViewModel, RequestDetailPage>("requestdetail")
                    .Map<TransitViewModel, TransitPage>("transit")
                    .Map<TicketDetailViewModel, TicketDetailPage>("ticketdetail")
                    .Map<BookingViewModel, BookingPage>("booking")
                    .Map<EventsViewModel, EventsPage>("events")
                    .Map<EventDetailViewModel, EventDetailPage>("eventdetail")
                    .Map<NewsViewModel, NewsPage>("news")
                    .Map<ArticleDetailViewModel, ArticleDetailPage>("articledetail")
                    .Map<OfficesViewModel, OfficesPage>("offices")
                    .Map<WalletViewModel, WalletPage>("wallet")
                    .Map<PermitsViewModel, PermitsPage>("permits")
                    .Map<PermitDetailViewModel, PermitDetailPage>("permitdetail")
                    .Map<PeopleViewModel, PeoplePage>("people")
                    .Map<FaqViewModel, FaqPage>("faq")
                    .Map<ContactViewModel, ContactPage>("contact")
                    .Map<AboutViewModel, AboutPage>("about")
                    .Map<HelpViewModel, HelpPage>("help")
                    .Map<NotificationsViewModel, NotificationsPage>("notifications")
                    .Map<SettingsViewModel, SettingsPage>("settings")
                    .Map<WhatsNewViewModel, WhatsNewPage>("whatsnew"))
                .UseDialogs()
                .UseAuth<SignInViewModel>());

        builder.Services.AddSingleton<IAuthState, DemoAuthState>();
        builder.Services.AddSingleton<ICivicApi, CivicApi>();
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignInPage>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ServicesViewModel>();
        builder.Services.AddTransient<ServicesPage>();
        builder.Services.AddTransient<RequestDetailViewModel>();
        builder.Services.AddTransient<RequestDetailPage>();
        builder.Services.AddTransient<TransitViewModel>();
        builder.Services.AddTransient<TransitPage>();
        builder.Services.AddTransient<TicketDetailViewModel>();
        builder.Services.AddTransient<TicketDetailPage>();
        builder.Services.AddTransient<BookingViewModel>();
        builder.Services.AddTransient<BookingPage>();
        builder.Services.AddTransient<EventsViewModel>();
        builder.Services.AddTransient<EventsPage>();
        builder.Services.AddTransient<EventDetailViewModel>();
        builder.Services.AddTransient<EventDetailPage>();
        builder.Services.AddTransient<NewsViewModel>();
        builder.Services.AddTransient<NewsPage>();
        builder.Services.AddTransient<ArticleDetailViewModel>();
        builder.Services.AddTransient<ArticleDetailPage>();
        builder.Services.AddTransient<OfficesViewModel>();
        builder.Services.AddTransient<OfficesPage>();
        builder.Services.AddTransient<WalletViewModel>();
        builder.Services.AddTransient<WalletPage>();
        builder.Services.AddTransient<PermitsViewModel>();
        builder.Services.AddTransient<PermitsPage>();
        builder.Services.AddTransient<PermitDetailViewModel>();
        builder.Services.AddTransient<PermitDetailPage>();
        builder.Services.AddTransient<PeopleViewModel>();
        builder.Services.AddTransient<PeoplePage>();
        builder.Services.AddTransient<FaqViewModel>();
        builder.Services.AddTransient<FaqPage>();
        builder.Services.AddTransient<ContactViewModel>();
        builder.Services.AddTransient<ContactPage>();
        builder.Services.AddTransient<AboutViewModel>();
        builder.Services.AddTransient<AboutPage>();
        builder.Services.AddTransient<HelpViewModel>();
        builder.Services.AddTransient<HelpPage>();
        builder.Services.AddTransient<NotificationsViewModel>();
        builder.Services.AddTransient<NotificationsPage>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<WhatsNewViewModel>();
        builder.Services.AddTransient<WhatsNewPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
