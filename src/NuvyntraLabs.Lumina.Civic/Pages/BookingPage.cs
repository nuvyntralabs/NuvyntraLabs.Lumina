using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class BookingPage : ContentPage
{
    public BookingPage(BookingViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Booking";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Form(new CivicModel
        {
            Title = "Booking",
            Subtitle = "Reserve a desk or a court.",
            Items = SeedRows.For(CivicSeed.Items, "Booking"),
            Actions = [
            new CivicNav("Events", vm.OpenEventsCommand, true),
            new CivicNav("Offices", vm.OpenOfficesCommand, false)
        ]
        });
    }
}
