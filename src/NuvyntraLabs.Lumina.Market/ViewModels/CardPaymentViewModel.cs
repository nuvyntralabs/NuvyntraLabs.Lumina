using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("cardpayment")]
public partial class CardPaymentViewModel : PageViewModel
{

    public CardPaymentViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPaymentResultAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PaymentResultViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSavedCardsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SavedCardsViewModel>(cancellationToken);

}
