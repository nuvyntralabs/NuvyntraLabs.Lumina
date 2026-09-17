using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ReviewsPage : ContentPage
{
    public ReviewsPage(ReviewsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Reviews";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Reviews",
            Subtitle = "Stars plus a short note.",
            Items = SeedRows.For(MarketSeed.Items, "Reviews"),
            Actions = [
            new MarketNav("View item", vm.OpenProductDetailCommand, true)
        ]
        });
    }
}
