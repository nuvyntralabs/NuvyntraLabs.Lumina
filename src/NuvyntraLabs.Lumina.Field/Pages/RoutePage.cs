using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class RoutePage : ContentPage
{
    public RoutePage(RouteViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Route";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Route",
            Subtitle = "Van plan.",
            Items = SeedRows.For(FieldSeed.Items, "Route"),
            Kind = "route",
            Actions = [
            new FieldNav("Jobs", vm.OpenJobsCommand, true),
            new FieldNav("Geofences", vm.OpenGeofencesCommand, false)
        ]
        });
    }
}
