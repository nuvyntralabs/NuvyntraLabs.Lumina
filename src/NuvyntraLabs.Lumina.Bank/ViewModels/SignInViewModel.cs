using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;
using Plugin.Maui.MVVMExpress.Auth;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("signin")]
public partial class SignInViewModel : PageViewModel
{

    readonly IAuthState _auth;
    [Notify] private string _email = "demo@lumina.app";
    [Notify] private string _password = DemoAuthState.DemoPassword;

    public SignInViewModel(IAuthState auth, INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

        _auth = auth;
        Email = "demo@lumina.app";

    }

    [AsyncModelCommand]
    private async Task SignInAsync(CancellationToken cancellationToken)
    {
        var result = await _auth.SignInAsync(Email, Password, cancellationToken).ConfigureAwait(false);
        if (!result.IsSuccess)
        {
            await Dialogs!.ErrorAsync(result.Error!, cancellationToken).ConfigureAwait(false);
            return;
        }

        await Navigator!.ResetAsync<DashboardViewModel>(cancellationToken).ConfigureAwait(false);
    }
    [AsyncModelCommand]
    private Task OpenPinLockAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PinLockViewModel>(cancellationToken);

}
