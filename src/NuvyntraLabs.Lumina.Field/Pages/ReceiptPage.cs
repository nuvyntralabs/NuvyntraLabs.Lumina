using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class ReceiptPage : LuminaPage
{
    public ReceiptPage(ReceiptViewModel vm) : base("Receipt", "Harbor Field", "Job ticket HF-204.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Receipt").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Printers", vm.OpenPrintersCommand, NVButtonVariant.Filled);        AddAction("JobDetail", vm.OpenJobDetailCommand, NVButtonVariant.Outline);
    }
}
