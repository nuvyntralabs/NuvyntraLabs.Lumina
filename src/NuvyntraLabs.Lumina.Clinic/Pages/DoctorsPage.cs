using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DoctorsPage : ContentPage
{
    public DoctorsPage(DoctorsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Doctors near you";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Doctors(new ClinicModel
        {
            Title = "Doctors near you",
            Subtitle = "Directory.",
            Items = SeedRows.For(ClinicSeed.Items, "Doctors"),
            Kind = "doctors",
            SelectedTab = "Doctors",
            Tabs = ClinicTheme.Tabs(vm.OpenHomeCommand, null, vm.OpenAppointmentsCommand, vm.OpenRecordsCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new ClinicNav("Doctor", vm.OpenDoctorProfileCommand, true, "icon_doctor"),
                new ClinicNav("Booking", vm.OpenBookingCommand, false, "icon_calendar"),
                new ClinicNav("Video", vm.OpenInCallCommand, false, "icon_video")
            ]
        });
    }
}
