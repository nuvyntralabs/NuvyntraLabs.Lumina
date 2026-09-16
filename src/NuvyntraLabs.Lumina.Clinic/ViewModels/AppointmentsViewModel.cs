using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("appointments")]
public partial class AppointmentsViewModel : PageViewModel
{

    public AppointmentsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenBookingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BookingViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenVisitDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<VisitDetailViewModel>(cancellationToken);

}
