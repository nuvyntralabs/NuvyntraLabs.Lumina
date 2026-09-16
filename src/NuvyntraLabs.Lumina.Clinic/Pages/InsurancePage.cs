using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InsurancePage : LuminaPage
{
    public InsurancePage(InsuranceViewModel vm) : base("Insurance", "Nuvexa Clinic", "Nuvexa Care · member 8841.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Insurance").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Filled);
    }
}
