using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class MedicationsPage : LuminaPage
{
    public MedicationsPage(MedicationsViewModel vm) : base("Medications", "Nuvexa Clinic", "Today's box.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Medications").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Prescriptions", vm.OpenPrescriptionsCommand, NVButtonVariant.Filled);
    }
}
