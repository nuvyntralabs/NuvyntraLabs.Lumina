using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class AppointmentsPage : ContentPage
{
    public AppointmentsPage(AppointmentsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "My appointments";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Visits(new ClinicModel
        {
            Title = "My appointments",
            Subtitle = "Upcoming and past visits.",
            Items = SeedRows.For(ClinicSeed.Items, "Appointments"),
            Kind = "visits",
            SelectedTab = "Visits",
            Tabs = ClinicTheme.Tabs(vm.OpenHomeCommand, vm.OpenDoctorsCommand, null, vm.OpenRecordsCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new ClinicNav("Booking", vm.OpenBookingCommand, true, "icon_calendar"),
                new ClinicNav("Visit", vm.OpenVisitDetailCommand, false, "icon_clinic")
            ]
        });
    }
}
