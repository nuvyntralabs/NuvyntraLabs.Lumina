using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class TrackingPage : ContentPage
{
    public TrackingPage(TrackingViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Tracking";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Tracking",
            Subtitle = "Packed → ship → door.",
            Items = SeedRows.For(MarketSeed.Items, "Tracking"),
            Actions = [
            new MarketNav("View order", vm.OpenOrderDetailCommand, true),
            new MarketNav("Message kitchen", vm.OpenSellerChatCommand, false)
        ]
        });
    }
}
