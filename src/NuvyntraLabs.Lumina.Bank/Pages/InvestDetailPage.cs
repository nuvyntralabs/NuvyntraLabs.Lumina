using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class InvestDetailPage : LuminaPage
{
    public InvestDetailPage(InvestDetailViewModel vm) : base("InvestDetail", "Aether Bank", "Aurora 80 — global equity tilt.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "InvestDetail").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Invest", vm.OpenInvestCommand, NVButtonVariant.Filled);        AddAction("Statements", vm.OpenStatementsCommand, NVButtonVariant.Outline);
    }
}
