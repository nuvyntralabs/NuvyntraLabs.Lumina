using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class WalkthroughPage : ContentPage
{
    public WalkthroughPage(WalkthroughViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Welcome";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Walkthrough(new MarketModel
        {
            Title = "Welcome",
            Subtitle = "Three beats before the store opens.",
            Items = SeedRows.For(MarketSeed.Items, "Walkthrough"),
            Actions =
            [
                new MarketNav("Get started", vm.OpenSignInCommand, true)
            ]
        });
    }
}
