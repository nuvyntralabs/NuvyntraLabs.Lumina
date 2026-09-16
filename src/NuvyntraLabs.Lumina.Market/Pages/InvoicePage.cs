using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class InvoicePage : LuminaPage
{
    public InvoicePage(InvoiceViewModel vm) : base("Invoice", "Lumina Market", "Studio invoice LM-1042.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Invoice").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Receipt", vm.OpenReceiptCommand, NVButtonVariant.Filled);        AddAction("Orders", vm.OpenOrdersCommand, NVButtonVariant.Outline);
    }
}
