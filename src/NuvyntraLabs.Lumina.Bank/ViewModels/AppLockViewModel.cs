using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("applock")]
public partial class AppLockViewModel : PageViewModel
{

    public AppLockViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPinLockAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PinLockViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SettingsViewModel>(cancellationToken);

}
