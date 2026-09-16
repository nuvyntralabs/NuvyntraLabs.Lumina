using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class HelpPage : LuminaPage
{
    public HelpPage(HelpViewModel vm) : base("Help", "Nuvexa Clinic", "Desk and after-hours.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Help").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Faq", vm.OpenFaqCommand, NVButtonVariant.Filled);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
