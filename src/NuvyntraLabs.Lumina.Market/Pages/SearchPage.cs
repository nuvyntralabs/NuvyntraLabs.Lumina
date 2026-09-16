using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SearchPage : LuminaPage
{
    public SearchPage(SearchViewModel vm) : base("Search", "Lumina Market", "Type a room or a craving.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Search").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Filters", vm.OpenFiltersCommand, NVButtonVariant.Filled);        AddAction("ProductDetail", vm.OpenProductDetailCommand, NVButtonVariant.Outline);
    }
}
