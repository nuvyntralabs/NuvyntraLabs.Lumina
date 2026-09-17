using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class OrdersPage : ContentPage
{
    public OrdersPage(OrdersViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Orders";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Orders(new MarketModel
        {
            Title = "Orders",
            Subtitle = "Open tickets.",
            Items = SeedRows.For(MarketSeed.Items, "Orders"),
            Kind = "orders",
            SelectedTab = "Orders",
            Tabs = MarketTheme.Tabs(vm.OpenHomeCommand, vm.OpenShopCommand, vm.OpenCartCommand, null, vm.OpenSettingsCommand),
            Actions =
            [
                new MarketNav("View order", vm.OpenOrderDetailCommand, true, "icon_orders"),
                new MarketNav("Track order", vm.OpenTrackingCommand, false, "icon_truck")
            ]
        });
    }
}
