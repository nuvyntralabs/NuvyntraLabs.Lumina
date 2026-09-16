using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("timesheet")]
public partial class TimesheetViewModel : PageViewModel
{

    public TimesheetViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenDashboardAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DashboardViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenJobsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobsViewModel>(cancellationToken);

}
