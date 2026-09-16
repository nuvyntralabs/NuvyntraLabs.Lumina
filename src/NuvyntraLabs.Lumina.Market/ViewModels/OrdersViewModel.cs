using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("orders")]
public partial class OrdersViewModel : PageViewModel
{

    public OrdersViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenOrderDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OrderDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenTrackingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TrackingViewModel>(cancellationToken);

}
