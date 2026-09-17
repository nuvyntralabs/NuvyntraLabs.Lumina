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
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenJobsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<JobsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAssetsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<AssetsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenOfflineQueueAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<OfflineQueueViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenDashboardAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DashboardViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPrintersAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PrintersViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenTimesheetAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TimesheetViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenTeamAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TeamViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSafetyAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SafetyViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenFilesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<FilesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenRouteAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<RouteViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSitesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SitesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenChecklistAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ChecklistViewModel>(cancellationToken);
}
