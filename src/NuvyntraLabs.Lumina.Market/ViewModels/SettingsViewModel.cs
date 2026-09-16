using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("settings")]
public partial class SettingsViewModel : PageViewModel
{

    public SettingsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenHelpAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HelpViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSubscriptionAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SubscriptionViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenStoreLocatorAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<StoreLocatorViewModel>(cancellationToken);

}
