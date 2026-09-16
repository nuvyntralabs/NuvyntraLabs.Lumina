using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("inspection")]
public partial class InspectionViewModel : PageViewModel
{

    public InspectionViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenEvidenceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<EvidenceViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenJobDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenChecklistAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ChecklistViewModel>(cancellationToken);

}
