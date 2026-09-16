using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("nfcscan")]
public partial class NfcScanViewModel : PageViewModel
{

    public NfcScanViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAssetsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AssetsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenAssetDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AssetDetailViewModel>(cancellationToken);

}
