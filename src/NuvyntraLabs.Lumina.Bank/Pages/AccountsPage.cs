using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class AccountsPage : LuminaPage
{
    public AccountsPage(AccountsViewModel vm) : base("Accounts", "Aether Bank", "Sterling books.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Accounts").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("AccountDetail", vm.OpenAccountDetailCommand, NVButtonVariant.Filled);        AddAction("Statements", vm.OpenStatementsCommand, NVButtonVariant.Outline);
    }
}
