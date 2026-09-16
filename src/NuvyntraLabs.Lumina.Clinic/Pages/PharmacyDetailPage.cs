using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class PharmacyDetailPage : LuminaPage
{
    public PharmacyDetailPage(PharmacyDetailViewModel vm) : base("PharmacyDetail", "Nuvexa Clinic", "Atorvastatin 10 mg film-coated.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "PharmacyDetail").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Pharmacy", vm.OpenPharmacyCommand, NVButtonVariant.Filled);
    }
}
