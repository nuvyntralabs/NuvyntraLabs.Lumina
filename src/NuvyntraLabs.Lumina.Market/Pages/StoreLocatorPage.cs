using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class StoreLocatorPage : ContentPage
{
    public StoreLocatorPage(StoreLocatorViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Store locator";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Store locator",
            Subtitle = "Studios that still have stock.",
            Items = SeedRows.For(MarketSeed.Items, "StoreLocator"),
            Actions = [
            new MarketNav("Shop", vm.OpenCatalogCommand, true)
        ]
        });
    }
}
