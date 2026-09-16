using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class GeofencesPage : LuminaPage
{
    public GeofencesPage(GeofencesViewModel vm) : base("Geofences", "Harbor Field", "Twenty circles max.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Geofences").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Sites", vm.OpenSitesCommand, NVButtonVariant.Filled);        AddAction("Route", vm.OpenRouteCommand, NVButtonVariant.Outline);
    }
}
