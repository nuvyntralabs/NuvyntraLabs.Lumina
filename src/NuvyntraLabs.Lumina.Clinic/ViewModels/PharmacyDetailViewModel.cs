using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("pharmacydetail")]
public partial class PharmacyDetailViewModel : PageViewModel
{

    public PharmacyDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPharmacyAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PharmacyViewModel>(cancellationToken);

}
