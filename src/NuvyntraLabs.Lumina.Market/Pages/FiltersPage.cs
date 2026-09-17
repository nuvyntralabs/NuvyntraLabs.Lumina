using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class FiltersPage : ContentPage
{
    public FiltersPage(FiltersViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Filters";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Form(new MarketModel
        {
            Title = "Filters",
            Subtitle = "Price, aisle, and delivery window.",
            Items = SeedRows.For(MarketSeed.Items, "Filters"),
            Actions = [
            new MarketNav("Shop", vm.OpenCatalogCommand, true)
        ]
        });
    }
}
