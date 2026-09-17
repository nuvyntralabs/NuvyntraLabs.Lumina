using Plugin.Maui.MVVMExpress.ComponentModel;
using Plugin.Maui.MVVMExpress.Dialogs;
using Plugin.Maui.MVVMExpress.Hosting;
using Plugin.Maui.MVVMExpress.Input;
using Plugin.Maui.MVVMExpress.Navigation;

namespace NuvyntraLabs.Lumina.Clinic;

[RegisterViewModel]
[Route("labresults")]
public partial class LabResultsViewModel : PageViewModel
{
    public LabResultsViewModel(INavigator navigator, IDialogs dialogs)
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
    private Task OpenLabDetailAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<LabDetailViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPrescriptionsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PrescriptionsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenDocumentsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<DocumentsViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenPharmacyAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<PharmacyViewModel>(cancellationToken);

    [AsyncModelCommand]
    private Task OpenMedicationsAsync(CancellationToken cancellationToken)
        => Navigator!.NavigateToAsync<MedicationsViewModel>(cancellationToken);
}
