using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class NotificationsPage : LuminaPage
{
    public NotificationsPage(NotificationsViewModel vm) : base("Notifications", "Nuvexa Clinic", "Reminders.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Notifications").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Appointments", vm.OpenAppointmentsCommand, NVButtonVariant.Filled);
    }
}
