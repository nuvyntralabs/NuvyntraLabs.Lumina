using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CatalogPage : LuminaPage
{
    public CatalogPage(CatalogViewModel vm) : base("Catalog", "Lumina Market", "Tile grid of this week's drop.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Catalog").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("ProductDetail", vm.OpenProductDetailCommand, NVButtonVariant.Filled);        AddAction("Filters", vm.OpenFiltersCommand, NVButtonVariant.Outline);        AddAction("Compare", vm.OpenCompareCommand, NVButtonVariant.Outline);
    }
}
