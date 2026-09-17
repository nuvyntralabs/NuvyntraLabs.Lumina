using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("catalog")]
public partial class CatalogViewModel : PageViewModel
{
    public CatalogViewModel(INavigator navigator, IDialogs dialogs)
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
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<SettingsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenProductDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ProductDetailViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenFiltersAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<FiltersViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenCompareAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CompareViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSearchAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SearchViewModel>(cancellationToken);
}
