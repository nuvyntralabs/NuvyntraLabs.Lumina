using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("accounts")]
public partial class AccountsViewModel : PageViewModel
{

    public AccountsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAccountDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AccountDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenStatementsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<StatementsViewModel>(cancellationToken);

}
