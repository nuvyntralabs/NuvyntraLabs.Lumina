using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("healthprofile")]
public partial class HealthProfileViewModel : PageViewModel
{

    public HealthProfileViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenVitalsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<VitalsViewModel>(cancellationToken);

}
