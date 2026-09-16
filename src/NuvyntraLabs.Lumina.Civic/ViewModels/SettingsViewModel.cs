using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("settings")]
public partial class SettingsViewModel : PageViewModel
{

    public SettingsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAboutAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AboutViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenHelpAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HelpViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenWhatsNewAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WhatsNewViewModel>(cancellationToken);

}
