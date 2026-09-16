using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("checkout")]
public partial class CheckoutViewModel : PageViewModel
{

    public CheckoutViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCardPaymentAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CardPaymentViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenAddressesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AddressesViewModel>(cancellationToken);

}
