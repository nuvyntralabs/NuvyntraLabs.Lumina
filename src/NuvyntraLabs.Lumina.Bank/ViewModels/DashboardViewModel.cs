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
    private Task OpenAccountsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AccountsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenCardsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CardsViewModel>(cancellationToken);
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
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SettingsViewModel>(cancellationToken);

}
