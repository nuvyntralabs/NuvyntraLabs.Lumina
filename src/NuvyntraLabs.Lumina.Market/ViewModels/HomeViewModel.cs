using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("home")]
public partial class HomeViewModel : PageViewModel
{

    public HomeViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCategoriesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CategoriesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenCatalogAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CatalogViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSearchAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SearchViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenCartAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CartViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenOrdersAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OrdersViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SettingsViewModel>(cancellationToken);

}
