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
    private Task OpenProductDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ProductDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenFiltersAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<FiltersViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenCompareAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CompareViewModel>(cancellationToken);

}
