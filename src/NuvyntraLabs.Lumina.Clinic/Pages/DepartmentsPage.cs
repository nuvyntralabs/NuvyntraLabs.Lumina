using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DepartmentsPage : LuminaPage
{
    public DepartmentsPage(DepartmentsViewModel vm) : base("Departments", "Nuvexa Clinic", "Floors in the Harbour building.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Departments").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Doctors", vm.OpenDoctorsCommand, NVButtonVariant.Filled);
    }
}
