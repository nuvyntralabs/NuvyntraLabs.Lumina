using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class StoreLocatorPage : LuminaPage
{
    public StoreLocatorPage(StoreLocatorViewModel vm) : base("StoreLocator", "Lumina Market", "Studios that still have stock.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "StoreLocator").ToList();
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
