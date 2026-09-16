using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("transit")]
public partial class TransitViewModel : PageViewModel
{

    public TransitViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenTicketDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TicketDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenBookingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BookingViewModel>(cancellationToken);

}
