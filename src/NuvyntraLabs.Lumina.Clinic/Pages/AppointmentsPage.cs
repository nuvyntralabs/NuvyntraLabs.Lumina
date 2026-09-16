using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class AppointmentsPage : LuminaPage
{
    public AppointmentsPage(AppointmentsViewModel vm) : base("Appointments", "Nuvexa Clinic", "Upcoming and past.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Appointments").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Booking", vm.OpenBookingCommand, NVButtonVariant.Filled);        AddAction("VisitDetail", vm.OpenVisitDetailCommand, NVButtonVariant.Outline);
    }
}
