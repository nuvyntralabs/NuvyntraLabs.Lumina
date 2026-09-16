using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("invoice")]
public partial class InvoiceViewModel : PageViewModel
{

    public InvoiceViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAccountDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AccountDetailViewModel>(cancellationToken);

}
