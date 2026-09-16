using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class SettingsPage : LuminaPage
{
    public SettingsPage(SettingsViewModel vm) : base("Settings", "Civic Pulse", "Alerts and theme.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Settings").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("About", vm.OpenAboutCommand, NVButtonVariant.Filled);        AddAction("Help", vm.OpenHelpCommand, NVButtonVariant.Outline);        AddAction("WhatsNew", vm.OpenWhatsNewCommand, NVButtonVariant.Outline);
    }
}
