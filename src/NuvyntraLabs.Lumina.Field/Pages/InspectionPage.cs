using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class InspectionPage : LuminaPage
{
    public InspectionPage(InspectionViewModel vm) : base("Inspection", "Harbor Field", "Checklist on the pump.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Inspection").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Evidence", vm.OpenEvidenceCommand, NVButtonVariant.Filled);        AddAction("JobDetail", vm.OpenJobDetailCommand, NVButtonVariant.Outline);        AddAction("Checklist", vm.OpenChecklistCommand, NVButtonVariant.Outline);
    }
}
