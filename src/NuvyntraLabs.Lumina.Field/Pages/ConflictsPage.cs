using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class ConflictsPage : ContentPage
{
    public ConflictsPage(ConflictsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Conflicts";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Conflicts",
            Subtitle = "Offline write vs desk edit.",
            Items = SeedRows.For(FieldSeed.Items, "Conflicts"),
            Kind = "conflicts",
            Actions = [
            new FieldNav("Queue", vm.OpenOfflineQueueCommand, true),
            new FieldNav("Job", vm.OpenJobDetailCommand, false)
        ]
        });
    }
}
