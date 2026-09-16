using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("bills")]
public partial class BillsViewModel : PageViewModel
{

    public BillsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenBillDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BillDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenTransferAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransferViewModel>(cancellationToken);

}
