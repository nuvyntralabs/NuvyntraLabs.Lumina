using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class TransferPage : LuminaPage
{
    public TransferPage(TransferViewModel vm) : base("Transfer", "Aether Bank", "Pay a person or a bill.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Transfer").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Payees", vm.OpenPayeesCommand, NVButtonVariant.Filled);        AddAction("Bills", vm.OpenBillsCommand, NVButtonVariant.Outline);
    }
}
