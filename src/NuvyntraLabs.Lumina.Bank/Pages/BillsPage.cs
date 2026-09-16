using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class BillsPage : LuminaPage
{
    public BillsPage(BillsViewModel vm) : base("Bills", "Aether Bank", "Due this month.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Bills").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("BillDetail", vm.OpenBillDetailCommand, NVButtonVariant.Filled);        AddAction("Transfer", vm.OpenTransferCommand, NVButtonVariant.Outline);
    }
}
