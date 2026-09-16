using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class NotificationsPage : LuminaPage
{
    public NotificationsPage(NotificationsViewModel vm) : base("Notifications", "Civic Pulse", "Borough pings.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Notifications").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Transit", vm.OpenTransitCommand, NVButtonVariant.Filled);        AddAction("Services", vm.OpenServicesCommand, NVButtonVariant.Outline);
    }
}
