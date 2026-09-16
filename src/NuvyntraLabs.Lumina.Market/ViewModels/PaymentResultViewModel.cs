using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("paymentresult")]
public partial class PaymentResultViewModel : PageViewModel
{

    public PaymentResultViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenTrackingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TrackingViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenOrdersAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OrdersViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenReceiptAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ReceiptViewModel>(cancellationToken);

}
