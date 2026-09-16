using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class StatementsPage : LuminaPage
{
    public StatementsPage(StatementsViewModel vm) : base("Statements", "Aether Bank", "PDF months.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Statements").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("AccountDetail", vm.OpenAccountDetailCommand, NVButtonVariant.Filled);        AddAction("Invoice", vm.OpenInvoiceCommand, NVButtonVariant.Outline);
    }
}
