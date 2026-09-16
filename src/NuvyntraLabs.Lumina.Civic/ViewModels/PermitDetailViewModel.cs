using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("permitdetail")]
public partial class PermitDetailViewModel : PageViewModel
{

    public PermitDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPermitsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PermitsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenWalletAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WalletViewModel>(cancellationToken);

}
