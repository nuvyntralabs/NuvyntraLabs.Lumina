using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class LabResultsPage : LuminaPage
{
    public LabResultsPage(LabResultsViewModel vm) : base("LabResults", "Nuvexa Clinic", "Panels in the last year.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "LabResults").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("LabDetail", vm.OpenLabDetailCommand, NVButtonVariant.Filled);
    }
}
