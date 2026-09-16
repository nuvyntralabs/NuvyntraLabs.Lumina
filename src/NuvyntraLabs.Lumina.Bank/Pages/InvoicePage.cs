using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class InvoicePage : LuminaPage
{
    public InvoicePage(InvoiceViewModel vm) : base("Invoice", "Aether Bank", "Advice note 12 Sep.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Invoice").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("AccountDetail", vm.OpenAccountDetailCommand, NVButtonVariant.Filled);
    }
}
