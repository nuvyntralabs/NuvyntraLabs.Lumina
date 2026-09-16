using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class BillDetailPage : LuminaPage
{
    public BillDetailPage(BillDetailViewModel vm) : base("BillDetail", "Aether Bank", "Council tax — September.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "BillDetail").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Bills", vm.OpenBillsCommand, NVButtonVariant.Filled);        AddAction("Transfer", vm.OpenTransferCommand, NVButtonVariant.Outline);
    }
}
