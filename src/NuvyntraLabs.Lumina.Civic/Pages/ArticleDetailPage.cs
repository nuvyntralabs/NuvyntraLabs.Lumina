using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class ArticleDetailPage : LuminaPage
{
    public ArticleDetailPage(ArticleDetailViewModel vm) : base("ArticleDetail", "Civic Pulse", "Bridge works — night closures.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "ArticleDetail").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("News", vm.OpenNewsCommand, NVButtonVariant.Filled);        AddAction("Transit", vm.OpenTransitCommand, NVButtonVariant.Outline);
    }
}
