using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class OfficesPage : ContentPage
{
    public OfficesPage(OfficesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Offices";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "Offices",
            Subtitle = "Counters still open.",
            Items = SeedRows.For(CivicSeed.Items, "Offices"),
            Kind = "offices",
            Actions = [
            new CivicNav("Booking", vm.OpenBookingCommand, true),
            new CivicNav("People", vm.OpenPeopleCommand, false)
        ]
        });
    }
}
