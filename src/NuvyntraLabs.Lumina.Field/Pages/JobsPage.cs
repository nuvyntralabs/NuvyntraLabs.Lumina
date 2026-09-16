using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class JobsPage : LuminaPage
{
    public JobsPage(JobsViewModel vm) : base("Jobs", "Harbor Field", "Assigned work.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Jobs").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("JobDetail", vm.OpenJobDetailCommand, NVButtonVariant.Filled);        AddAction("Route", vm.OpenRouteCommand, NVButtonVariant.Outline);
    }
}
