using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class NotificationsPage : ContentPage
{
    public NotificationsPage(NotificationsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Notifications";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Notifications",
            Subtitle = "Pushes you would have felt.",
            Items = SeedRows.For(MarketSeed.Items, "Notifications"),
            Actions = [
            new MarketNav("Orders", vm.OpenOrdersCommand, true),
            new MarketNav("Track order", vm.OpenTrackingCommand, false)
        ]
        });
    }
}
