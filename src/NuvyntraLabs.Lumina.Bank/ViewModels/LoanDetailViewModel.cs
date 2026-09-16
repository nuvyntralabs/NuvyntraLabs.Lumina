using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("loandetail")]
public partial class LoanDetailViewModel : PageViewModel
{

    public LoanDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenLoansAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<LoansViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenTransferAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransferViewModel>(cancellationToken);

}
