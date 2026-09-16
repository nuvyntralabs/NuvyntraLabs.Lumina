using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("permits")]
public partial class PermitsViewModel : PageViewModel
{

    public PermitsViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenPermitDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PermitDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenServicesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ServicesViewModel>(cancellationToken);

}
