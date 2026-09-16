using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("cart")]
public partial class CartViewModel : PageViewModel
{

    public CartViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCheckoutAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CheckoutViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenWishlistAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WishlistViewModel>(cancellationToken);

}
