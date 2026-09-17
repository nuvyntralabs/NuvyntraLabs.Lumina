using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SearchPage : ContentPage
{
    public SearchPage(SearchViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Search";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Search(new MarketModel
        {
            Title = "Search",
            Subtitle = "Type a room or a craving.",
            Items = SeedRows.For(MarketSeed.Items, "Search"),
            Kind = "search",
            Actions =
            [
                new MarketNav("View item", vm.OpenProductDetailCommand, true, "icon_shop"),
                new MarketNav("Filters", vm.OpenFiltersCommand, false, "icon_filter")
            ]
        });
    }
}
