using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class WalkthroughPage : LuminaPage
{
    public WalkthroughPage(WalkthroughViewModel vm) : base("Walkthrough", "Lumina Market", "Three beats before the store opens.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Walkthrough").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        Root.Add(new NVCarousel { Items = rows.Select(r => r.Title).ToList() });
        Root.Add(new NVDotIndicator { Count = 3, Index = 0 });

        
AddAction("SignIn", vm.OpenSignInCommand, NVButtonVariant.Filled);
    }
}
