using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("people")]
public partial class PeopleViewModel : PageViewModel
{

    public PeopleViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenContactAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<ContactViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenOfficesAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<OfficesViewModel>(cancellationToken);

}
