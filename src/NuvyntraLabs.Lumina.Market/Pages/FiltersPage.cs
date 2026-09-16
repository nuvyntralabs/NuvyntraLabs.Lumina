using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class FiltersPage : LuminaPage
{
    public FiltersPage(FiltersViewModel vm) : base("Filters", "Lumina Market", "Price, aisle, and delivery window.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Filters").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Catalog", vm.OpenCatalogCommand, NVButtonVariant.Filled);
    }
}
