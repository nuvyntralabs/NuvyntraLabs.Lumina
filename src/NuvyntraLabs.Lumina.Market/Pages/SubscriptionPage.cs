using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SubscriptionPage : LuminaPage
{
    public SubscriptionPage(SubscriptionViewModel vm) : base("Subscription", "Lumina Market", "Weekly produce crate.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Subscription").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Checkout", vm.OpenCheckoutCommand, NVButtonVariant.Filled);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
