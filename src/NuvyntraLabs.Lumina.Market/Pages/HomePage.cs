using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Home";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Home(new MarketModel
        {
            Title = "Home",
            Subtitle = "Today at Harbour Market.",
            Items = SeedRows.For(MarketSeed.Items, "Home"),
            Aisles = SeedRows.For(MarketSeed.Items, "Categories"),
            SelectedTab = "Home",
            Tabs = MarketTheme.Tabs(vm.OpenHomeCommand, vm.OpenShopCommand, vm.OpenCartCommand, vm.OpenOrdersCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new MarketNav("Aisles", vm.OpenCategoriesCommand, true, "icon_shop"),
                new MarketNav("Shop", vm.OpenShopCommand, false, "icon_shop"),
                new MarketNav("Search", vm.OpenSearchCommand, false, "icon_search"),
                new MarketNav("Cart", vm.OpenCartCommand, false, "icon_cart"),
                new MarketNav("Orders", vm.OpenOrdersCommand, false, "icon_orders"),
                new MarketNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell"),
                new MarketNav("You", vm.OpenSettingsCommand, false, "icon_user")
            ]
        });
    }
}
