using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("medications")]
public partial class MedicationsViewModel : PageViewModel
{

    public MedicationsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPrescriptionsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PrescriptionsViewModel>(cancellationToken);

}
