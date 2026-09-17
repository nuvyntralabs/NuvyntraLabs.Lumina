using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CartPage : ContentPage
{
    public CartPage(CartViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "My cart";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Cart(new MarketModel
        {
            Title = "My cart",
            Subtitle = "Two lines, one kitchen.",
            Items = SeedRows.For(MarketSeed.Items, "Cart"),
            Kind = "cart",
            SelectedTab = "Cart",
            Tabs = MarketTheme.Tabs(vm.OpenHomeCommand, vm.OpenShopCommand, null, vm.OpenOrdersCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new MarketNav("Place order", vm.OpenCheckoutCommand, true, "icon_cart"),
                new MarketNav("Saved", vm.OpenWishlistCommand, false, "icon_heart")
            ]
        });
    }
}
