using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("prescriptions")]
public partial class PrescriptionsViewModel : PageViewModel
{

    public PrescriptionsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPharmacyAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PharmacyViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenVisitDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<VisitDetailViewModel>(cancellationToken);

}
