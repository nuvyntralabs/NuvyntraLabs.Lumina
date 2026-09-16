using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("settings")]
public partial class SettingsViewModel : PageViewModel
{

    public SettingsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenDashboardAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DashboardViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenPrintersAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PrintersViewModel>(cancellationToken);

}
