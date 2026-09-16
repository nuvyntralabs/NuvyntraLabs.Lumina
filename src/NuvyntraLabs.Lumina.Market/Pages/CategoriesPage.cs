using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CategoriesPage : LuminaPage
{
    public CategoriesPage(CategoriesViewModel vm) : base("Categories", "Lumina Market", "Aisles you actually walk.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Categories").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Catalog", vm.OpenCatalogCommand, NVButtonVariant.Filled);        AddAction("Search", vm.OpenSearchCommand, NVButtonVariant.Outline);
    }
}
