using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class NewsPage : ContentPage
{
    public NewsPage(NewsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "News";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "News",
            Subtitle = "Borough notes.",
            Items = SeedRows.For(CivicSeed.Items, "News"),
            Kind = "news",
            Actions =
            [
                new CivicNav("Story", vm.OpenArticleDetailCommand, true, "icon_news")
            ]
        });
    }
}
