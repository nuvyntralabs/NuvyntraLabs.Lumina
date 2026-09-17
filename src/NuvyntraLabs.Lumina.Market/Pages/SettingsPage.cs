using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Account";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Account(new MarketModel
        {
            Title = "Account",
            Subtitle = "You, orders, and help.",
            Items = SeedRows.For(MarketSeed.Items, "Settings"),
            Kind = "account",
            SelectedTab = "You",
            Tabs = MarketTheme.Tabs(vm.OpenHomeCommand, vm.OpenShopCommand, vm.OpenCartCommand, vm.OpenOrdersCommand, null),
            Actions =
            [
                new MarketNav("Orders", vm.OpenOrdersCommand, false, "icon_orders", "Track and buy again"),
                new MarketNav("Wishlist", vm.OpenWishlistCommand, false, "icon_heart", "Saved for later"),
                new MarketNav("Saved cards", vm.OpenSavedCardsCommand, false, "icon_card", "Visa and kitchen tab"),
                new MarketNav("Addresses", vm.OpenAddressesCommand, false, "icon_pin", "Studio loft and office"),
                new MarketNav("Membership", vm.OpenSubscriptionCommand, false, "icon_star", "Aurora crate"),
                new MarketNav("Help", vm.OpenHelpCommand, true, "icon_help", "Slots and returns"),
                new MarketNav("Find a store", vm.OpenStoreLocatorCommand, false, "icon_store", "Harbour Walk"),
                new MarketNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell", "Courier updates")
            ]
        });
    }
}
