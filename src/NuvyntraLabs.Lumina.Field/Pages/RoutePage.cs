using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class RoutePage : LuminaPage
{
    public RoutePage(RouteViewModel vm) : base("Route", "Harbor Field", "Van plan.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Route").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Jobs", vm.OpenJobsCommand, NVButtonVariant.Filled);        AddAction("Geofences", vm.OpenGeofencesCommand, NVButtonVariant.Outline);
    }
}
