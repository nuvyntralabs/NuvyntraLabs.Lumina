using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("home")]
public partial class HomeViewModel : PageViewModel
{

    public HomeViewModel(INavigator navigator, IDialogs dialogs)
        : base(navigator, dialogs)
    {

    }

    [AsyncModelCommand]
    private Task OpenAppointmentsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<AppointmentsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenDoctorsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DoctorsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenPharmacyAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PharmacyViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenLabResultsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<LabResultsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenInboxAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InboxViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);
    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<SettingsViewModel>(cancellationToken);

}
