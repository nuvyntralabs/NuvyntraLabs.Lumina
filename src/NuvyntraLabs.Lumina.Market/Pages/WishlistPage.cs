using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class WishlistPage : ContentPage
{
    public WishlistPage(WishlistViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Wishlist";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Catalog(new MarketModel
        {
            Title = "Wishlist",
            Subtitle = "Saved for later.",
            Items = SeedRows.For(MarketSeed.Items, "Wishlist"),
            Actions = [
            new MarketNav("View item", vm.OpenProductDetailCommand, true),
            new MarketNav("Cart", vm.OpenCartCommand, false)
        ]
        });
    }
}
