using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("forgotpassword")]
public partial class ForgotPasswordViewModel : PageViewModel
{

    public ForgotPasswordViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenResetPasswordAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ResetPasswordViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSignInAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SignInViewModel>(cancellationToken);

}
