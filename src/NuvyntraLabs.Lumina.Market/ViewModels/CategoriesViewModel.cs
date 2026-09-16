using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("categories")]
public partial class CategoriesViewModel : PageViewModel
{

    public CategoriesViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCatalogAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CatalogViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSearchAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SearchViewModel>(cancellationToken);

}
