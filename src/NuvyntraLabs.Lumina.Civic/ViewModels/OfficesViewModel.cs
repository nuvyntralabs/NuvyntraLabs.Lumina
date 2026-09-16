using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Civic;

[RegisterViewModel]
[Route("offices")]
public partial class OfficesViewModel : PageViewModel
{

    public OfficesViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenBookingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BookingViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenPeopleAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PeopleViewModel>(cancellationToken);

}
