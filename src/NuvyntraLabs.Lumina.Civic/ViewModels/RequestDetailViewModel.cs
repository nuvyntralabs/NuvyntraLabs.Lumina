using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("requestdetail")]
public partial class RequestDetailViewModel : PageViewModel
{

    public RequestDetailViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenServicesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ServicesViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenOfficesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OfficesViewModel>(cancellationToken);

}
