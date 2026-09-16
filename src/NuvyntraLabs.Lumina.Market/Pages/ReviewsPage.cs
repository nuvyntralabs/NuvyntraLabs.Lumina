using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ReviewsPage : LuminaPage
{
    public ReviewsPage(ReviewsViewModel vm) : base("Reviews", "Lumina Market", "Stars plus a short note.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Reviews").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("ProductDetail", vm.OpenProductDetailCommand, NVButtonVariant.Filled);
    }
}
