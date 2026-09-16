using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("pinlock")]
public partial class PinLockViewModel : PageViewModel
{

    public PinLockViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenDashboardAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<DashboardViewModel>(cancellationToken);

}
