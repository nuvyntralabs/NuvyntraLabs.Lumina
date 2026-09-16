using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("services")]
public partial class ServicesViewModel : PageViewModel
{

    public ServicesViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenRequestDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<RequestDetailViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenPermitsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PermitsViewModel>(cancellationToken);

}
