using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("transfer")]
public partial class TransferViewModel : PageViewModel
{
    public TransferViewModel(INavigator navigator, IDialogs dialogs)
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
    private Task OpenCardsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<CardsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenMoreAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<SettingsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPayeesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PayeesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenBillsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BillsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenBeneficiariesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BeneficiariesViewModel>(cancellationToken);
}
