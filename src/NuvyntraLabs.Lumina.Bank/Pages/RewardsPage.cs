using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class RewardsPage : LuminaPage
{
    public RewardsPage(RewardsViewModel vm) : base("Rewards", "Aether Bank", "Aurora points.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Rewards").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Cards", vm.OpenCardsCommand, NVButtonVariant.Filled);
    }
}
