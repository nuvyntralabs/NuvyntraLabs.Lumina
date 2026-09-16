using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class PharmacyPage : LuminaPage
{
    public PharmacyPage(PharmacyViewModel vm) : base("Pharmacy", "Nuvexa Clinic", "Harbour pharmacy counter.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Pharmacy").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("PharmacyDetail", vm.OpenPharmacyDetailCommand, NVButtonVariant.Filled);        AddAction("Prescriptions", vm.OpenPrescriptionsCommand, NVButtonVariant.Outline);
    }
}
