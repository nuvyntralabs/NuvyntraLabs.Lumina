using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class AssetDetailPage : LuminaPage
{
    public AssetDetailPage(AssetDetailViewModel vm) : base("AssetDetail", "Harbor Field", "PUMP-441 — Flygt storm pump.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "AssetDetail").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Inspection", vm.OpenInspectionCommand, NVButtonVariant.Filled);        AddAction("Files", vm.OpenFilesCommand, NVButtonVariant.Outline);
    }
}
