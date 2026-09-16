using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class WishlistPage : LuminaPage
{
    public WishlistPage(WishlistViewModel vm) : base("Wishlist", "Lumina Market", "Saved for later.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Wishlist").ToList();
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
