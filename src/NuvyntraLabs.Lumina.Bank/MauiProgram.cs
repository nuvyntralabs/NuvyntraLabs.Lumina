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

namespace NuvyntraLabs.Lumina.Bank;

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
                o.Path = Path.Combine(FileSystem.AppDataDirectory, "lumina-bank.nvx");
                o.CreateIfMissing = true;
            })
            .UseHttpForge()
            .UseMvvmExpress(o => o
                .UseNavigationPage((nav, _) => nav
                    .Map<SignInViewModel, SignInPage>("signin")
                    .Map<PinLockViewModel, PinLockPage>("pinlock")
                    .Map<DashboardViewModel, DashboardPage>("dashboard")
                    .Map<AccountsViewModel, AccountsPage>("accounts")
                    .Map<AccountDetailViewModel, AccountDetailPage>("accountdetail")
                    .Map<CardsViewModel, CardsPage>("cards")
                    .Map<CardDetailViewModel, CardDetailPage>("carddetail")
                    .Map<TransferViewModel, TransferPage>("transfer")
                    .Map<PayeesViewModel, PayeesPage>("payees")
                    .Map<BillsViewModel, BillsPage>("bills")
                    .Map<BillDetailViewModel, BillDetailPage>("billdetail")
                    .Map<InvestViewModel, InvestPage>("invest")
                    .Map<InvestDetailViewModel, InvestDetailPage>("investdetail")
                    .Map<KycViewModel, KycPage>("kyc")
                    .Map<StatementsViewModel, StatementsPage>("statements")
                    .Map<InvoiceViewModel, InvoicePage>("invoice")
                    .Map<LoansViewModel, LoansPage>("loans")
                    .Map<LoanDetailViewModel, LoanDetailPage>("loandetail")
                    .Map<RewardsViewModel, RewardsPage>("rewards")
                    .Map<BeneficiariesViewModel, BeneficiariesPage>("beneficiaries")
                    .Map<SupportViewModel, SupportPage>("support")
                    .Map<NotificationsViewModel, NotificationsPage>("notifications")
                    .Map<AppLockViewModel, AppLockPage>("applock")
                    .Map<SettingsViewModel, SettingsPage>("settings"))
                .UseDialogs()
                .UseAuth<SignInViewModel>());

        builder.Services.AddSingleton<IAuthState, DemoAuthState>();
        builder.Services.AddSingleton<IBankApi, BankApi>();
        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignInPage>();
        builder.Services.AddTransient<PinLockViewModel>();
        builder.Services.AddTransient<PinLockPage>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<AccountsViewModel>();
        builder.Services.AddTransient<AccountsPage>();
        builder.Services.AddTransient<AccountDetailViewModel>();
        builder.Services.AddTransient<AccountDetailPage>();
        builder.Services.AddTransient<CardsViewModel>();
        builder.Services.AddTransient<CardsPage>();
        builder.Services.AddTransient<CardDetailViewModel>();
        builder.Services.AddTransient<CardDetailPage>();
        builder.Services.AddTransient<TransferViewModel>();
        builder.Services.AddTransient<TransferPage>();
        builder.Services.AddTransient<PayeesViewModel>();
        builder.Services.AddTransient<PayeesPage>();
        builder.Services.AddTransient<BillsViewModel>();
        builder.Services.AddTransient<BillsPage>();
        builder.Services.AddTransient<BillDetailViewModel>();
        builder.Services.AddTransient<BillDetailPage>();
        builder.Services.AddTransient<InvestViewModel>();
        builder.Services.AddTransient<InvestPage>();
        builder.Services.AddTransient<InvestDetailViewModel>();
        builder.Services.AddTransient<InvestDetailPage>();
        builder.Services.AddTransient<KycViewModel>();
        builder.Services.AddTransient<KycPage>();
        builder.Services.AddTransient<StatementsViewModel>();
        builder.Services.AddTransient<StatementsPage>();
        builder.Services.AddTransient<InvoiceViewModel>();
        builder.Services.AddTransient<InvoicePage>();
        builder.Services.AddTransient<LoansViewModel>();
        builder.Services.AddTransient<LoansPage>();
        builder.Services.AddTransient<LoanDetailViewModel>();
        builder.Services.AddTransient<LoanDetailPage>();
        builder.Services.AddTransient<RewardsViewModel>();
        builder.Services.AddTransient<RewardsPage>();
        builder.Services.AddTransient<BeneficiariesViewModel>();
        builder.Services.AddTransient<BeneficiariesPage>();
        builder.Services.AddTransient<SupportViewModel>();
        builder.Services.AddTransient<SupportPage>();
        builder.Services.AddTransient<NotificationsViewModel>();
        builder.Services.AddTransient<NotificationsPage>();
        builder.Services.AddTransient<AppLockViewModel>();
        builder.Services.AddTransient<AppLockPage>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<SettingsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
