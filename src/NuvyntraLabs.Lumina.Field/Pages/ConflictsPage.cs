using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class ConflictsPage : LuminaPage
{
    public ConflictsPage(ConflictsViewModel vm) : base("Conflicts", "Harbor Field", "Offline write vs desk edit.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Conflicts").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("OfflineQueue", vm.OpenOfflineQueueCommand, NVButtonVariant.Filled);        AddAction("JobDetail", vm.OpenJobDetailCommand, NVButtonVariant.Outline);
    }
}
