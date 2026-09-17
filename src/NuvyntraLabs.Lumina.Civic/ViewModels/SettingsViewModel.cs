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
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenServicesAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<ServicesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenTransitAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<TransitViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenWalletAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<WalletViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAboutAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AboutViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenHelpAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HelpViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenWhatsNewAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WhatsNewViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPermitsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PermitsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenOfficesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OfficesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPeopleAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PeopleViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenFaqAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<FaqViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenNewsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NewsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenEventsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<EventsViewModel>(cancellationToken);
}
