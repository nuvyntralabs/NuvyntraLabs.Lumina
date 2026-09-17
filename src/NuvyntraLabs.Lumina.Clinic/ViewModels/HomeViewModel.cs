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
    private Task OpenHomeAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<HomeViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenDoctorsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<DoctorsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenAppointmentsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<AppointmentsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenRecordsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<LabResultsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenSettingsAsync(CancellationToken cancellationToken)
        => Navigator!.ResetAsync<SettingsViewModel>(cancellationToken);

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
    private Task OpenInCallAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InCallViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenBookingAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<BookingViewModel>(cancellationToken);
}
