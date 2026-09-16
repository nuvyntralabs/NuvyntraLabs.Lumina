using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class LoansPage : LuminaPage
{
    public LoansPage(LoansViewModel vm) : base("Loans", "Aether Bank", "Open credit.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Loans").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("LoanDetail", vm.OpenLoanDetailCommand, NVButtonVariant.Filled);
    }
}
