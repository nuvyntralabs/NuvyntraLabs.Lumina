using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class EventDetailPage : ContentPage
{
    public EventDetailPage(EventDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Event detail";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Detail(new CivicModel
        {
            Title = "Event detail",
            Subtitle = "Harbour night market.",
            Items = SeedRows.For(CivicSeed.Items, "EventDetail"),
            Actions = [
            new CivicNav("Events", vm.OpenEventsCommand, true),
            new CivicNav("Offices", vm.OpenOfficesCommand, false)
        ]
        });
    }
}
