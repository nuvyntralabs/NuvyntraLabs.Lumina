using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("events")]
public partial class EventsViewModel : PageViewModel
{

    public EventsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenEventDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<EventDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenBookingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BookingViewModel>(cancellationToken);

}
