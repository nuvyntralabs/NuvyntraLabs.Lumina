using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("compare")]
public partial class CompareViewModel : PageViewModel
{

    public CompareViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenProductDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ProductDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenCartAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CartViewModel>(cancellationToken);

}
