using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("settings")]
public partial class SettingsViewModel : PageViewModel
{

    public SettingsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenInsuranceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InsuranceViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenHealthProfileAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HealthProfileViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenHelpAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HelpViewModel>(cancellationToken);

}
