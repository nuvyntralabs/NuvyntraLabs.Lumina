using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("settings")]
public partial class SettingsViewModel : PageViewModel
{
    public SettingsViewModel(INavigator navigator, IDialogs dialogs)
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
    private Task OpenInsuranceAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InsuranceViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenHealthProfileAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HealthProfileViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenHelpAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<HelpViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenVitalsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<VitalsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenInboxAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<InboxViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenDocumentsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DocumentsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPrescriptionsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PrescriptionsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPharmacyAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PharmacyViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenMedicationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<MedicationsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenNotificationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<NotificationsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenDepartmentsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DepartmentsViewModel>(cancellationToken);
}
