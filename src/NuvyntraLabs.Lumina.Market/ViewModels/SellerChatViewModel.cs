using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("sellerchat")]
public partial class SellerChatViewModel : PageViewModel
{

    public SellerChatViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenOrderDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OrderDetailViewModel>(cancellationToken);

}
