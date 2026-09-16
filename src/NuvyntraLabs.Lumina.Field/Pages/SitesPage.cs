using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SitesPage : LuminaPage
{
    public SitesPage(SitesViewModel vm) : base("Sites", "Harbor Field", "Yards on the fence list.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Sites").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Geofences", vm.OpenGeofencesCommand, NVButtonVariant.Filled);        AddAction("JobDetail", vm.OpenJobDetailCommand, NVButtonVariant.Outline);
    }
}
