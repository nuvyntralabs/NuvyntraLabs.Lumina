using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class NewsPage : LuminaPage
{
    public NewsPage(NewsViewModel vm) : base("News", "Civic Pulse", "Borough notes.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "News").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("ArticleDetail", vm.OpenArticleDetailCommand, NVButtonVariant.Filled);
    }
}
