using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class AboutPage : LuminaPage
{
    public AboutPage(AboutViewModel vm) : base("About", "Civic Pulse", "Civic Pulse · Lumina prototype.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "About").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Filled);
    }
}
