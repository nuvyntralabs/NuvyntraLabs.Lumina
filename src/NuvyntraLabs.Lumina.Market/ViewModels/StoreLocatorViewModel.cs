using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Market;

[RegisterViewModel]
[Route("storelocator")]
public partial class StoreLocatorViewModel : PageViewModel
{

    public StoreLocatorViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenCatalogAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<CatalogViewModel>(cancellationToken);

}
