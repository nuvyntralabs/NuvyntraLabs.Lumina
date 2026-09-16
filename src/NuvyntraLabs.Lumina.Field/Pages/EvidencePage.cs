using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class EvidencePage : LuminaPage
{
    public EvidencePage(EvidenceViewModel vm) : base("Evidence", "Harbor Field", "Photos queued for upload.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Evidence").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Inspection", vm.OpenInspectionCommand, NVButtonVariant.Filled);        AddAction("OfflineQueue", vm.OpenOfflineQueueCommand, NVButtonVariant.Outline);
    }
}
