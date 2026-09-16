using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("assets")]
public partial class AssetsViewModel : PageViewModel
{

    public AssetsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAssetDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AssetDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenNfcScanAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NfcScanViewModel>(cancellationToken);

}
