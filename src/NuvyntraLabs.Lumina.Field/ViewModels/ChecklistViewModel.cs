using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("checklist")]
public partial class ChecklistViewModel : PageViewModel
{

    public ChecklistViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenSafetyAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SafetyViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenInspectionAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InspectionViewModel>(cancellationToken);

}
