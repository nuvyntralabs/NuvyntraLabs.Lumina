using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("ticketdetail")]
public partial class TicketDetailViewModel : PageViewModel
{

    public TicketDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenTransitAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransitViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenWalletAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WalletViewModel>(cancellationToken);

}
