using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CartPage : LuminaPage
{
    public CartPage(CartViewModel vm) : base("Cart", "Lumina Market", "Two lines, one kitchen.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Cart").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Checkout", vm.OpenCheckoutCommand, NVButtonVariant.Filled);        AddAction("Wishlist", vm.OpenWishlistCommand, NVButtonVariant.Outline);
    }
}
