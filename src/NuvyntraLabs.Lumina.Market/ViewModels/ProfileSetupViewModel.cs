using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("profilesetup")]
public partial class ProfileSetupViewModel : PageViewModel
{

    public ProfileSetupViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);

}
