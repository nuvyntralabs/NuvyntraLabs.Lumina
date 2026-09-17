using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class EventsPage : ContentPage
{
    public EventsPage(EventsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Events";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "Events",
            Subtitle = "This week on the square.",
            Items = SeedRows.For(CivicSeed.Items, "Events"),
            Kind = "events",
            Actions =
            [
                new CivicNav("Event", vm.OpenEventDetailCommand, true, "icon_calendar"),
                new CivicNav("Booking", vm.OpenBookingCommand, false, "icon_calendar", "Reserve a stall or court")
            ]
        });
    }
}
