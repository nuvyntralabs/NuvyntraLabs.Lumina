using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ComparePage : LuminaPage
{
    public ComparePage(CompareViewModel vm) : base("Compare", "Lumina Market", "Chair vs chair.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Compare").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("ProductDetail", vm.OpenProductDetailCommand, NVButtonVariant.Filled);        AddAction("Cart", vm.OpenCartCommand, NVButtonVariant.Outline);
    }
}
