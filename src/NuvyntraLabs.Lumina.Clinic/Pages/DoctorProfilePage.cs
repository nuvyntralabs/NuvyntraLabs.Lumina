using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DoctorProfilePage : LuminaPage
{
    public DoctorProfilePage(DoctorProfileViewModel vm) : base("DoctorProfile", "Nuvexa Clinic", "Dr. Priya Iyer — cardiology.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "DoctorProfile").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Booking", vm.OpenBookingCommand, NVButtonVariant.Filled);        AddAction("Inbox", vm.OpenInboxCommand, NVButtonVariant.Outline);
    }
}
