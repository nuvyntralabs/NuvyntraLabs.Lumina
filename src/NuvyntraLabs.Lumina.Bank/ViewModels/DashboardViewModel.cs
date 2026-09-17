using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("dashboard")]
public partial class DashboardViewModel : PageViewModel
{
    public DashboardViewModel(INavigator navigator, IDialogs dialogs)
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
    private Task OpenMoreAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<SettingsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenTransferAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransferViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenInvestAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InvestViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenBillsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BillsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenRewardsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<RewardsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAccountDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AccountDetailViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenStatementsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<StatementsViewModel>(cancellationToken);
}
