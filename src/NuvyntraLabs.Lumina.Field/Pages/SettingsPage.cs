using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SettingsPage : LuminaPage
{
    public SettingsPage(SettingsViewModel vm) : base("Settings", "Harbor Field", "Keep-awake, offline, pins.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Settings").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Dashboard", vm.OpenDashboardCommand, NVButtonVariant.Filled);        AddAction("Printers", vm.OpenPrintersCommand, NVButtonVariant.Outline);
    }
}
