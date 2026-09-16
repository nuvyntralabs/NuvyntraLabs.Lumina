using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("evidence")]
public partial class EvidenceViewModel : PageViewModel
{

    public EvidenceViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenInspectionAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InspectionViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenOfflineQueueAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OfflineQueueViewModel>(cancellationToken);

}
