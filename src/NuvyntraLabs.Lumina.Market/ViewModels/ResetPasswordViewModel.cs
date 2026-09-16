using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("resetpassword")]
public partial class ResetPasswordViewModel : PageViewModel
{

    public ResetPasswordViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenSignInAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SignInViewModel>(cancellationToken);

}
