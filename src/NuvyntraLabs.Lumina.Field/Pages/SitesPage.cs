using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SitesPage : ContentPage
{
    public SitesPage(SitesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Sites";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Sites",
            Subtitle = "Yards on the fence list.",
            Items = SeedRows.For(FieldSeed.Items, "Sites"),
            Kind = "sites",
            Actions = [
            new FieldNav("Geofences", vm.OpenGeofencesCommand, true),
            new FieldNav("Job", vm.OpenJobDetailCommand, false)
        ]
        });
    }
}
