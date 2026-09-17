using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CatalogPage : ContentPage
{
    public CatalogPage(CatalogViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Shop";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Catalog(new MarketModel
        {
            Title = "Shop",
            Subtitle = "Tile grid of this week's drop.",
            Items = SeedRows.For(MarketSeed.Items, "Catalog"),
            Kind = "shop",
            SelectedTab = "Shop",
            Tabs = MarketTheme.Tabs(vm.OpenHomeCommand, null, vm.OpenCartCommand, vm.OpenOrdersCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new MarketNav("View item", vm.OpenProductDetailCommand, true, "icon_shop"),
                new MarketNav("Filters", vm.OpenFiltersCommand, false, "icon_filter"),
                new MarketNav("Compare", vm.OpenCompareCommand, false, "icon_shop"),
                new MarketNav("Search", vm.OpenSearchCommand, false, "icon_search")
            ]
        });
    }
}
