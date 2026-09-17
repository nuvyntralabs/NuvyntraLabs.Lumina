using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Account";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Account(new ClinicModel
        {
            Title = "Account",
            Subtitle = "You, records, and support.",
            Items = SeedRows.For(ClinicSeed.Items, "Settings"),
            Kind = "account",
            SelectedTab = "You",
            Tabs = ClinicTheme.Tabs(vm.OpenHomeCommand, vm.OpenDoctorsCommand, vm.OpenAppointmentsCommand, vm.OpenRecordsCommand, null),
            Actions =
            [
                new ClinicNav("Health profile", vm.OpenHealthProfileCommand, false, "icon_user", "Allergies and GP"),
                new ClinicNav("Vitals", vm.OpenVitalsCommand, false, "icon_heart", "Home readings"),
                new ClinicNav("Insurance", vm.OpenInsuranceCommand, true, "icon_shield", "Harbour Plus"),
                new ClinicNav("Labs", vm.OpenRecordsCommand, false, "icon_lab", "Panels this year"),
                new ClinicNav("Prescriptions", vm.OpenPrescriptionsCommand, false, "icon_pill", "Active scripts"),
                new ClinicNav("Documents", vm.OpenDocumentsCommand, false, "icon_doc", "Letters and PDFs"),
                new ClinicNav("Pharmacy", vm.OpenPharmacyCommand, false, "icon_clinic", "Harbour counter"),
                new ClinicNav("Medications", vm.OpenMedicationsCommand, false, "icon_pill", "Today's box"),
                new ClinicNav("Inbox", vm.OpenInboxCommand, false, "icon_chat", "Care threads"),
                new ClinicNav("Help", vm.OpenHelpCommand, false, "icon_help", "Desk and after hours"),
                new ClinicNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell", "Reminders"),
                new ClinicNav("Departments", vm.OpenDepartmentsCommand, false, "icon_clinic", "Harbour floors")
            ]
        });
    }
}
