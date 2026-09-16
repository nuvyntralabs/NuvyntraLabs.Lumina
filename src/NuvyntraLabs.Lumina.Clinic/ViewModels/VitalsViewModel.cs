using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("vitals")]
public partial class VitalsViewModel : PageViewModel
{

    public VitalsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenHealthProfileAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HealthProfileViewModel>(cancellationToken);

}
