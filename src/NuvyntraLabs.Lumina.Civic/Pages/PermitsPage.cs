using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class PermitsPage : LuminaPage
{
    public PermitsPage(PermitsViewModel vm) : base("Permits", "Civic Pulse", "Paper the borough issued.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Permits").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("PermitDetail", vm.OpenPermitDetailCommand, NVButtonVariant.Filled);        AddAction("Services", vm.OpenServicesCommand, NVButtonVariant.Outline);
    }
}
