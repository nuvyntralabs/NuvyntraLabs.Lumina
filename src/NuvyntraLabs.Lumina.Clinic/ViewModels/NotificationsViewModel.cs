using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("notifications")]
public partial class NotificationsViewModel : PageViewModel
{

    public NotificationsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAppointmentsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AppointmentsViewModel>(cancellationToken);

}
