using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("departments")]
public partial class DepartmentsViewModel : PageViewModel
{

    public DepartmentsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenDoctorsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DoctorsViewModel>(cancellationToken);

}
