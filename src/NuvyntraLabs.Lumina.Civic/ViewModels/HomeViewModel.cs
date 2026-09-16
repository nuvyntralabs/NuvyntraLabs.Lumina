using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("home")]
public partial class HomeViewModel : PageViewModel
{

    public HomeViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenServicesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ServicesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenTransitAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TransitViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenEventsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<EventsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenNewsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NewsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenWalletAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WalletViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SettingsViewModel>(cancellationToken);

}
