using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class FilesPage : LuminaPage
{
    public FilesPage(FilesViewModel vm) : base("Files", "Harbor Field", "Drawings on the device.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Files").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("AssetDetail", vm.OpenAssetDetailCommand, NVButtonVariant.Filled);
    }
}
