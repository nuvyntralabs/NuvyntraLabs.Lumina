using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("sites")]
public partial class SitesViewModel : PageViewModel
{

    public SitesViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenGeofencesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<GeofencesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenJobDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobDetailViewModel>(cancellationToken);

}
