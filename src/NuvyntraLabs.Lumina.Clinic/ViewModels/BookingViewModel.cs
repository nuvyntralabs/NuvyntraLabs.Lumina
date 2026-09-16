using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("booking")]
public partial class BookingViewModel : PageViewModel
{

    public BookingViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAppointmentsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AppointmentsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenDoctorsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DoctorsViewModel>(cancellationToken);

}
