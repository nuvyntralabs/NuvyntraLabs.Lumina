using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class HelpPage : LuminaPage
{
    public HelpPage(HelpViewModel vm) : base("Help", "Civic Pulse", "How to use Pulse.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Help").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Faq", vm.OpenFaqCommand, NVButtonVariant.Filled);        AddAction("Contact", vm.OpenContactCommand, NVButtonVariant.Outline);
    }
}
