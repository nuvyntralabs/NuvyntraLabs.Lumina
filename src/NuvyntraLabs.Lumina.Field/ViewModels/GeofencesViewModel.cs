using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("geofences")]
public partial class GeofencesViewModel : PageViewModel
{

    public GeofencesViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenSitesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SitesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenRouteAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<RouteViewModel>(cancellationToken);

}
