using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class TimesheetPage : LuminaPage
{
    public TimesheetPage(TimesheetViewModel vm) : base("Timesheet", "Harbor Field", "Tuesday hours.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Timesheet").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Dashboard", vm.OpenDashboardCommand, NVButtonVariant.Filled);        AddAction("Jobs", vm.OpenJobsCommand, NVButtonVariant.Outline);
    }
}
