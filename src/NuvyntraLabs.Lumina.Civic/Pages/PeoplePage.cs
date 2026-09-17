using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class PeoplePage : ContentPage
{
    public PeoplePage(PeopleViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "People";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "People",
            Subtitle = "Ward contacts.",
            Items = SeedRows.For(CivicSeed.Items, "People"),
            Kind = "people",
            Actions = [
            new CivicNav("Contact", vm.OpenContactCommand, true),
            new CivicNav("Offices", vm.OpenOfficesCommand, false)
        ]
        });
    }
}
