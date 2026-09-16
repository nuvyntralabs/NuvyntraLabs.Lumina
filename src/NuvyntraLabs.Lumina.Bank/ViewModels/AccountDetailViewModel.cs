using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("accountdetail")]
public partial class AccountDetailViewModel : PageViewModel
{

    public AccountDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenTransferAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransferViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenStatementsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<StatementsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenInvoiceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InvoiceViewModel>(cancellationToken);

}
