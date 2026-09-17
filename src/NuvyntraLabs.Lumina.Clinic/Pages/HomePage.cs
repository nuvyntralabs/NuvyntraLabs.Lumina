using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Home";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Home(new ClinicModel
        {
            Title = "Home",
            Subtitle = "Today at Nuvexa Clinic.",
            Items = SeedRows.For(ClinicSeed.Items, "Home"),
            SelectedTab = "Home",
            Tabs = ClinicTheme.Tabs(vm.OpenHomeCommand, vm.OpenDoctorsCommand, vm.OpenAppointmentsCommand, vm.OpenRecordsCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new ClinicNav("Doctors", vm.OpenDoctorsCommand, false, "icon_doctor"),
                new ClinicNav("Visits", vm.OpenAppointmentsCommand, true, "icon_calendar"),
                new ClinicNav("Pharmacy", vm.OpenPharmacyCommand, false, "icon_pill"),
                new ClinicNav("Labs", vm.OpenRecordsCommand, false, "icon_lab"),
                new ClinicNav("Video consult", vm.OpenInCallCommand, false, "icon_video"),
                new ClinicNav("Inbox", vm.OpenInboxCommand, false, "icon_chat"),
                new ClinicNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell"),
                new ClinicNav("Booking", vm.OpenBookingCommand, false, "icon_calendar"),
                new ClinicNav("You", vm.OpenSettingsCommand, false, "icon_user")
            ]
        });
    }
}
