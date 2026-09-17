using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class TeamPage : ContentPage
{
    public TeamPage(TeamViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Team";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Team",
            Subtitle = "Crew 4 thread.",
            Items = SeedRows.For(FieldSeed.Items, "Team"),
            Kind = "team",
            Actions = [
            new FieldNav("Job", vm.OpenJobDetailCommand, true)
        ]
        });
    }
}
