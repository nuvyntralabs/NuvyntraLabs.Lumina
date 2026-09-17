using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class InspectionPage : ContentPage
{
    public InspectionPage(InspectionViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Inspection";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Form(new FieldModel
        {
            Title = "Inspection",
            Subtitle = "Checklist on the pump.",
            Items = SeedRows.For(FieldSeed.Items, "Inspection"),
            Actions = [
            new FieldNav("Evidence", vm.OpenEvidenceCommand, true),
            new FieldNav("Job", vm.OpenJobDetailCommand, false),
            new FieldNav("Checklist", vm.OpenChecklistCommand, false)
        ]
        });
    }
}
