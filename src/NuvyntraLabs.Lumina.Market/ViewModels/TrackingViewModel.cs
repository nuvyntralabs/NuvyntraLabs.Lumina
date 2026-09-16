using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("tracking")]
public partial class TrackingViewModel : PageViewModel
{

    public TrackingViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenOrderDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OrderDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSellerChatAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SellerChatViewModel>(cancellationToken);

}
