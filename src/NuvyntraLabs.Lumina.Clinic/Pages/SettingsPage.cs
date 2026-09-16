using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class SettingsPage : LuminaPage
{
    public SettingsPage(SettingsViewModel vm) : base("Settings", "Nuvexa Clinic", "Privacy and flags.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Settings").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Insurance", vm.OpenInsuranceCommand, NVButtonVariant.Filled);        AddAction("HealthProfile", vm.OpenHealthProfileCommand, NVButtonVariant.Outline);        AddAction("Help", vm.OpenHelpCommand, NVButtonVariant.Outline);
    }
}
