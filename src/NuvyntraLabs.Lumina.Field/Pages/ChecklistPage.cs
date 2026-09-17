using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class ChecklistPage : ContentPage
{
    public ChecklistPage(ChecklistViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Checklist";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Form(new FieldModel
        {
            Title = "Checklist",
            Subtitle = "Safety before the hatch.",
            Items = SeedRows.For(FieldSeed.Items, "Checklist"),
            Actions = [
            new FieldNav("Safety", vm.OpenSafetyCommand, true),
            new FieldNav("Inspection", vm.OpenInspectionCommand, false)
        ]
        });
    }
}
