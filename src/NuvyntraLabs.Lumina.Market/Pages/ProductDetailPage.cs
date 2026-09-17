using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ProductDetailPage : ContentPage
{
    public ProductDetailPage(ProductDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Cedar lounge chair";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Product(new MarketModel
        {
            Title = "Cedar lounge chair",
            Subtitle = "Oiled oak, wool seat — weekend drop.",
            Items = SeedRows.For(MarketSeed.Items, "ProductDetail"),
            Kind = "product",
            Actions =
            [
                new MarketNav("Buy now", vm.OpenCheckoutCommand, true, "icon_cart"),
                new MarketNav("Add to cart", vm.OpenCartCommand, false, "icon_cart"),
                new MarketNav("Reviews", vm.OpenReviewsCommand, false, "icon_star"),
                new MarketNav("Compare", vm.OpenCompareCommand, false, "icon_shop")
            ]
        });
    }
}
