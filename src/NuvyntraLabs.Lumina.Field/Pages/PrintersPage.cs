using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class PrintersPage : LuminaPage
{
    public PrintersPage(PrintersViewModel vm) : base("Printers", "Harbor Field", "SPP and BLE receipts.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Printers").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Receipt", vm.OpenReceiptCommand, NVButtonVariant.Filled);
    }
}
