using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class AccountDetailPage : LuminaPage
{
    public AccountDetailPage(AccountDetailViewModel vm) : base("AccountDetail", "Aether Bank", "Current 40-88-41.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "AccountDetail").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Transfer", vm.OpenTransferCommand, NVButtonVariant.Filled);        AddAction("Statements", vm.OpenStatementsCommand, NVButtonVariant.Outline);        AddAction("Invoice", vm.OpenInvoiceCommand, NVButtonVariant.Outline);
    }
}
