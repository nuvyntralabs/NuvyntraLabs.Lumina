using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SubscriptionPage : ContentPage
{
    public SubscriptionPage(SubscriptionViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Subscription";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Form(new MarketModel
        {
            Title = "Aurora crate",
            Subtitle = "Weekly produce crate.",
            Items = SeedRows.For(MarketSeed.Items, "Subscription"),
            Kind = "subscription",
            Actions = [
            new MarketNav("Checkout", vm.OpenCheckoutCommand, true),
            new MarketNav("You", vm.OpenSettingsCommand, false)
        ]
        });
    }
}
