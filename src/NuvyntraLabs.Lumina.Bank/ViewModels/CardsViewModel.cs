using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("cards")]
public partial class CardsViewModel : PageViewModel
{

    public CardsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCardDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CardDetailViewModel>(cancellationToken);

}
