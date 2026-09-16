using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class NfcScanPage : LuminaPage
{
    public NfcScanPage(NfcScanViewModel vm) : base("NfcScan", "Harbor Field", "Hold the puck to the asset plate.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "NfcScan").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Assets", vm.OpenAssetsCommand, NVButtonVariant.Filled);        AddAction("AssetDetail", vm.OpenAssetDetailCommand, NVButtonVariant.Outline);
    }
}
