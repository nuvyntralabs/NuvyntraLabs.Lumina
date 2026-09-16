using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ProductDetailPage : LuminaPage
{
    public ProductDetailPage(ProductDetailViewModel vm) : base("ProductDetail", "Lumina Market", "Cedar lounge chair — oiled oak, wool seat.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "ProductDetail").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Cart", vm.OpenCartCommand, NVButtonVariant.Filled);        AddAction("Wishlist", vm.OpenWishlistCommand, NVButtonVariant.Outline);        AddAction("Reviews", vm.OpenReviewsCommand, NVButtonVariant.Outline);        AddAction("Compare", vm.OpenCompareCommand, NVButtonVariant.Outline);
    }
}
