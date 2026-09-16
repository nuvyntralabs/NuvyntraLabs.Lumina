using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("reviews")]
public partial class ReviewsViewModel : PageViewModel
{

    public ReviewsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenProductDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ProductDetailViewModel>(cancellationToken);

}
