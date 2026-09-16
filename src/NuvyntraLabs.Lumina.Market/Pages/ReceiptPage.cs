using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ReceiptPage : LuminaPage
{
    public ReceiptPage(ReceiptViewModel vm) : base("Receipt", "Lumina Market", "Thermal-style ticket.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Receipt").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Orders", vm.OpenOrdersCommand, NVButtonVariant.Filled);
    }
}
