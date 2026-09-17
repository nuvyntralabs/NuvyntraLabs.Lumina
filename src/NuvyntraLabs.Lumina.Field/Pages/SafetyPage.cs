using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SafetyPage : ContentPage
{
    public SafetyPage(SafetyViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Safety";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Safety",
            Subtitle = "Brief — confined space.",
            Items = SeedRows.For(FieldSeed.Items, "Safety"),
            Kind = "safety",
            Actions = [
            new FieldNav("Checklist", vm.OpenChecklistCommand, true),
            new FieldNav("Job", vm.OpenJobDetailCommand, false)
        ]
        });
    }
}
