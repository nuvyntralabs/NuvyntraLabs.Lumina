using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class ContactPage : LuminaPage
{
    public ContactPage(ContactViewModel vm) : base("Contact", "Civic Pulse", "Write the desk.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Contact").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Services", vm.OpenServicesCommand, NVButtonVariant.Filled);        AddAction("Help", vm.OpenHelpCommand, NVButtonVariant.Outline);
    }
}
