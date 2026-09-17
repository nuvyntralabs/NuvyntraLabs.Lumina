using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CategoriesPage : ContentPage
{
    public CategoriesPage(CategoriesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "All categories";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "All categories",
            Subtitle = "Aisles you actually walk.",
            Items = SeedRows.For(MarketSeed.Items, "Categories"),
            Kind = "aisles",
            Actions = [
            new MarketNav("Shop", vm.OpenCatalogCommand, true),
            new MarketNav("Search", vm.OpenSearchCommand, false)
        ]
        });
    }
}
