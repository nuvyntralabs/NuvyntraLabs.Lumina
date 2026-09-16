using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class PeoplePage : LuminaPage
{
    public PeoplePage(PeopleViewModel vm) : base("People", "Civic Pulse", "Ward contacts.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "People").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Contact", vm.OpenContactCommand, NVButtonVariant.Filled);        AddAction("Offices", vm.OpenOfficesCommand, NVButtonVariant.Outline);
    }
}
