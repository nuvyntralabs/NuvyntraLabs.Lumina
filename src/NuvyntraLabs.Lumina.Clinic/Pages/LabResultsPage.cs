using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class LabResultsPage : ContentPage
{
    public LabResultsPage(LabResultsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Records";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Records(new ClinicModel
        {
            Title = "Records",
            Subtitle = "Labs, scripts, and letters.",
            Items = SeedRows.For(ClinicSeed.Items, "LabResults"),
            Kind = "records",
            SelectedTab = "Records",
            Tabs = ClinicTheme.Tabs(vm.OpenHomeCommand, vm.OpenDoctorsCommand, vm.OpenAppointmentsCommand, null, vm.OpenSettingsCommand),
            Actions =
            [
                new ClinicNav("Lab", vm.OpenLabDetailCommand, true, "icon_lab"),
                new ClinicNav("Prescriptions", vm.OpenPrescriptionsCommand, false, "icon_pill"),
                new ClinicNav("Documents", vm.OpenDocumentsCommand, false, "icon_doc"),
                new ClinicNav("Pharmacy", vm.OpenPharmacyCommand, false, "icon_clinic"),
                new ClinicNav("Medications", vm.OpenMedicationsCommand, false, "icon_pill")
            ]
        });
    }
}
