using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("dashboard")]
public partial class DashboardViewModel : PageViewModel
{

    public DashboardViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenJobsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenTimesheetAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TimesheetViewModel>(cancellationToken);

}
