using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Field;

[RegisterViewModel]
[Route("jobdetail")]
public partial class JobDetailViewModel : PageViewModel
{

    public JobDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenInspectionAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InspectionViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenEvidenceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<EvidenceViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSitesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SitesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenTeamAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<TeamViewModel>(cancellationToken);

}
