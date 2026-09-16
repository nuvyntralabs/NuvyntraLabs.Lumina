using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DoctorsPage : LuminaPage
{
    public DoctorsPage(DoctorsViewModel vm) : base("Doctors", "Nuvexa Clinic", "Directory.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Doctors").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("DoctorProfile", vm.OpenDoctorProfileCommand, NVButtonVariant.Filled);        AddAction("Booking", vm.OpenBookingCommand, NVButtonVariant.Outline);
    }
}
