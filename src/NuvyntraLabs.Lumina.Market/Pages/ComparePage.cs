using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ComparePage : ContentPage
{
    public ComparePage(CompareViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Compare";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Product(new MarketModel
        {
            Title = "Compare",
            Subtitle = "Chair vs chair.",
            Items = SeedRows.For(MarketSeed.Items, "Compare"),
            Actions = [
            new MarketNav("View item", vm.OpenProductDetailCommand, true),
            new MarketNav("Cart", vm.OpenCartCommand, false)
        ]
        });
    }
}
