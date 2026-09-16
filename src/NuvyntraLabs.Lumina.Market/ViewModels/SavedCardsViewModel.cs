using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("savedcards")]
public partial class SavedCardsViewModel : PageViewModel
{

    public SavedCardsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCardPaymentAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CardPaymentViewModel>(cancellationToken);

}
