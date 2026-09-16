using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class PrescriptionsPage : LuminaPage
{
    public PrescriptionsPage(PrescriptionsViewModel vm) : base("Prescriptions", "Nuvexa Clinic", "Active scripts.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Prescriptions").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Pharmacy", vm.OpenPharmacyCommand, NVButtonVariant.Filled);        AddAction("VisitDetail", vm.OpenVisitDetailCommand, NVButtonVariant.Outline);
    }
}
