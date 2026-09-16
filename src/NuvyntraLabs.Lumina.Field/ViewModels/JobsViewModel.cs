using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("jobs")]
public partial class JobsViewModel : PageViewModel
{

    public JobsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenJobDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenRouteAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<RouteViewModel>(cancellationToken);

}
