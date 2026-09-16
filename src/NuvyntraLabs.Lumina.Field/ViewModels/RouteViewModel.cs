using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("route")]
public partial class RouteViewModel : PageViewModel
{

    public RouteViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenJobsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenGeofencesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<GeofencesViewModel>(cancellationToken);

}
