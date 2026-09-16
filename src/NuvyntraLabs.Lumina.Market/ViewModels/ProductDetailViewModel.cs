using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("productdetail")]
public partial class ProductDetailViewModel : PageViewModel
{

    public ProductDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCartAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CartViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenWishlistAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WishlistViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenReviewsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ReviewsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenCompareAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CompareViewModel>(cancellationToken);

}
