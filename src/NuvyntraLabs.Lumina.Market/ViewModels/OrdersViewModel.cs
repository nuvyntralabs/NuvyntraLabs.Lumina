using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("orders")]
public partial class OrdersViewModel : PageViewModel
{
    public OrdersViewModel(INavigator navigator, IDialogs dialogs)
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
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<SettingsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenOrderDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OrderDetailViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenTrackingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TrackingViewModel>(cancellationToken);
}
