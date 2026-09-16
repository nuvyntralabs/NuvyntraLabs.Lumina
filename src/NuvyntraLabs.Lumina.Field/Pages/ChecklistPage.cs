using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class ChecklistPage : LuminaPage
{
    public ChecklistPage(ChecklistViewModel vm) : base("Checklist", "Harbor Field", "Safety before the hatch.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Checklist").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Safety", vm.OpenSafetyCommand, NVButtonVariant.Filled);        AddAction("Inspection", vm.OpenInspectionCommand, NVButtonVariant.Outline);
    }
}
