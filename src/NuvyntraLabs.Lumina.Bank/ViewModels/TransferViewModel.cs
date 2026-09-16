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
    private Task OpenPayeesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PayeesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenBillsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BillsViewModel>(cancellationToken);

}
