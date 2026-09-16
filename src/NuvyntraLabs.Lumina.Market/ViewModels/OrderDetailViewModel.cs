using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("orderdetail")]
public partial class OrderDetailViewModel : PageViewModel
{

    public OrderDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenTrackingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TrackingViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenInvoiceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InvoiceViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenReceiptAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ReceiptViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSellerChatAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SellerChatViewModel>(cancellationToken);

}
