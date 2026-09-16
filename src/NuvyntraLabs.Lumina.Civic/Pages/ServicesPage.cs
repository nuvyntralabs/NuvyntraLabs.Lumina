using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class ServicesPage : LuminaPage
{
    public ServicesPage(ServicesViewModel vm) : base("Services", "Civic Pulse", "Requests the desk still owns.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Services").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("RequestDetail", vm.OpenRequestDetailCommand, NVButtonVariant.Filled);        AddAction("Permits", vm.OpenPermitsCommand, NVButtonVariant.Outline);
    }
}
