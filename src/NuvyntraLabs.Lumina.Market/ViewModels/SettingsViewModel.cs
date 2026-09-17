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
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenShopAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<CatalogViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenCartAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<CartViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenOrdersAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<OrdersViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenHelpAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HelpViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSubscriptionAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SubscriptionViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenStoreLocatorAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<StoreLocatorViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenWishlistAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<WishlistViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAddressesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AddressesViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSavedCardsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SavedCardsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);
}
