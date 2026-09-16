using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class NotificationsPage : LuminaPage
{
    public NotificationsPage(NotificationsViewModel vm) : base("Notifications", "Lumina Market", "Pushes you would have felt.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Notifications").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Orders", vm.OpenOrdersCommand, NVButtonVariant.Filled);        AddAction("Tracking", vm.OpenTrackingCommand, NVButtonVariant.Outline);
    }
}
