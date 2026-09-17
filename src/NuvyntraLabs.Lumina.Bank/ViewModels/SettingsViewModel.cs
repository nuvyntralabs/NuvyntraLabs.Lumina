using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("settings")]
public partial class SettingsViewModel : PageViewModel
{
    public SettingsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {
    }

    [AsyncModelCommand]
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<DashboardViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAccountsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<AccountsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPayAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<TransferViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenCardsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<CardsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenKycAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<KycViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAppLockAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AppLockViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSupportAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SupportViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenInvestAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InvestViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenLoansAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<LoansViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenRewardsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<RewardsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenStatementsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<StatementsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenInvoiceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InvoiceViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenBillsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BillsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPayeesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PayeesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenBeneficiariesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BeneficiariesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);
}
