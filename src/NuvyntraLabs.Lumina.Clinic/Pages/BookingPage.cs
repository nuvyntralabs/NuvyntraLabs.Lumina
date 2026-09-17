using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class BookingPage : ContentPage
{
    public BookingPage(BookingViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Book appointment";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Booking(new ClinicModel
        {
            Title = "Book appointment",
            Subtitle = "Pick a slot on the calendar.",
            Items = SeedRows.For(ClinicSeed.Items, "Booking"),
            Kind = "booking",
            Actions =
            [
                new ClinicNav("Confirm appointment", vm.OpenAppointmentsCommand, true, "icon_calendar"),
                new ClinicNav("Doctors", vm.OpenDoctorsCommand, false, "icon_doctor")
            ]
        });
    }
}
