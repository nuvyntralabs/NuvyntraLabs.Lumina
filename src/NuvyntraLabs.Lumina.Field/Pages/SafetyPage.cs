using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SafetyPage : LuminaPage
{
    public SafetyPage(SafetyViewModel vm) : base("Safety", "Harbor Field", "Brief — confined space.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Safety").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Checklist", vm.OpenChecklistCommand, NVButtonVariant.Filled);        AddAction("JobDetail", vm.OpenJobDetailCommand, NVButtonVariant.Outline);
    }
}
