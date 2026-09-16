using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("pharmacy")]
public partial class PharmacyViewModel : PageViewModel
{

    public PharmacyViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPharmacyDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PharmacyDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenPrescriptionsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PrescriptionsViewModel>(cancellationToken);

}
