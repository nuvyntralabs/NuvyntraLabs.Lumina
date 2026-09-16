using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class NotificationsPage : LuminaPage
{
    public NotificationsPage(NotificationsViewModel vm) : base("Notifications", "Harbor Field", "Dispatch.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Notifications").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Jobs", vm.OpenJobsCommand, NVButtonVariant.Filled);
    }
}
