using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("walkthrough")]
public partial class WalkthroughViewModel : PageViewModel
{

    public WalkthroughViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenSignInAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SignInViewModel>(cancellationToken);

}
