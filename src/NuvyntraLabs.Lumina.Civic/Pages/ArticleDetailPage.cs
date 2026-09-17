using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class ArticleDetailPage : ContentPage
{
    public ArticleDetailPage(ArticleDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Article detail";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Detail(new CivicModel
        {
            Title = "Article detail",
            Subtitle = "Bridge works — night closures.",
            Items = SeedRows.For(CivicSeed.Items, "ArticleDetail"),
            Actions = [
            new CivicNav("News", vm.OpenNewsCommand, true),
            new CivicNav("Transit", vm.OpenTransitCommand, false)
        ]
        });
    }
}
