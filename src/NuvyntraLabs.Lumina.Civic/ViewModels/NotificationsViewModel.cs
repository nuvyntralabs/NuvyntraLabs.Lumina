using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("notifications")]
public partial class NotificationsViewModel : PageViewModel
{

    public NotificationsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenTransitAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransitViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenServicesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ServicesViewModel>(cancellationToken);

}
