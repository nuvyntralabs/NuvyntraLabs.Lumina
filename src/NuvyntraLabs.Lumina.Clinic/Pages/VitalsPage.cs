using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class VitalsPage : LuminaPage
{
    public VitalsPage(VitalsViewModel vm) : base("Vitals", "Nuvexa Clinic", "Home readings this week.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Vitals").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("HealthProfile", vm.OpenHealthProfileCommand, NVButtonVariant.Filled);
    }
}
