using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("carddetail")]
public partial class CardDetailViewModel : PageViewModel
{

    public CardDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCardsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CardsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenAppLockAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AppLockViewModel>(cancellationToken);

}
