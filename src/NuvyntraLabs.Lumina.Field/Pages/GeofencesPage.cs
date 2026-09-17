using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class GeofencesPage : ContentPage
{
    public GeofencesPage(GeofencesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Geofences";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Geofences",
            Subtitle = "Twenty circles max.",
            Items = SeedRows.For(FieldSeed.Items, "Geofences"),
            Kind = "geofences",
            Actions = [
            new FieldNav("Sites", vm.OpenSitesCommand, true),
            new FieldNav("Route", vm.OpenRouteCommand, false)
        ]
        });
    }
}
