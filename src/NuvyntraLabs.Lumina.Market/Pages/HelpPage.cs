using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class HelpPage : ContentPage
{
    public HelpPage(HelpViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Help";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Help",
            Subtitle = "How Market works.",
            Items = SeedRows.For(MarketSeed.Items, "Help"),
            Kind = "help",
            Actions = [
            new MarketNav("You", vm.OpenSettingsCommand, true)
        ]
        });
    }
}
