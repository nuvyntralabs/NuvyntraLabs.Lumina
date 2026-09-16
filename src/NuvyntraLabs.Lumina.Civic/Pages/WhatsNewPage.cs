using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class WhatsNewPage : LuminaPage
{
    public WhatsNewPage(WhatsNewViewModel vm) : base("WhatsNew", "Civic Pulse", "1.0 prototype notes.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "WhatsNew").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("About", vm.OpenAboutCommand, NVButtonVariant.Filled);
    }
}
