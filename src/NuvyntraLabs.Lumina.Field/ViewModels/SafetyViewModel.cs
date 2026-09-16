using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("safety")]
public partial class SafetyViewModel : PageViewModel
{

    public SafetyViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenChecklistAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ChecklistViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenJobDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<JobDetailViewModel>(cancellationToken);

}
