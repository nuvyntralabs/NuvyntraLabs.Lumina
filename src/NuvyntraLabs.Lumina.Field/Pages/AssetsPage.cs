using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class AssetsPage : LuminaPage
{
    public AssetsPage(AssetsViewModel vm) : base("Assets", "Harbor Field", "Yard register.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Assets").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("AssetDetail", vm.OpenAssetDetailCommand, NVButtonVariant.Filled);        AddAction("NfcScan", vm.OpenNfcScanCommand, NVButtonVariant.Outline);
    }
}
