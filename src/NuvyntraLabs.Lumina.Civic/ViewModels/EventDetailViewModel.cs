using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("eventdetail")]
public partial class EventDetailViewModel : PageViewModel
{

    public EventDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenEventsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<EventsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenOfficesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OfficesViewModel>(cancellationToken);

}
