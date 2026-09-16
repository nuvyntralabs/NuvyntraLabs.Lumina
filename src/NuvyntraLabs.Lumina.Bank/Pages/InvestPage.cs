using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class InvestPage : LuminaPage
{
    public InvestPage(InvestViewModel vm) : base("Invest", "Aether Bank", "Wealth sleeves.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Invest").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("InvestDetail", vm.OpenInvestDetailCommand, NVButtonVariant.Filled);
    }
}
