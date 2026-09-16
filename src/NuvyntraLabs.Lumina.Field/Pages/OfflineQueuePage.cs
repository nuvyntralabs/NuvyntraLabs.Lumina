using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class OfflineQueuePage : LuminaPage
{
    public OfflineQueuePage(OfflineQueueViewModel vm) : base("OfflineQueue", "Harbor Field", "Waiting for real internet.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "OfflineQueue").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Conflicts", vm.OpenConflictsCommand, NVButtonVariant.Filled);        AddAction("Evidence", vm.OpenEvidenceCommand, NVButtonVariant.Outline);
    }
}
