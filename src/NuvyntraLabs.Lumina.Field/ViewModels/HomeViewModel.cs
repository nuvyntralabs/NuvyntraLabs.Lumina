using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("home")]
public partial class HomeViewModel : PageViewModel
{

    public HomeViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenJobsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSitesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SitesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenAssetsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AssetsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenOfflineQueueAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OfflineQueueViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenDashboardAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DashboardViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SettingsViewModel>(cancellationToken);

}
