using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Bank;

[RegisterViewModel]
[Route("settings")]
public partial class SettingsViewModel : PageViewModel
{

    public SettingsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenKycAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<KycViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenAppLockAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AppLockViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSupportAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SupportViewModel>(cancellationToken);

}
