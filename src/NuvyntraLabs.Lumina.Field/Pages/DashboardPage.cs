using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class DashboardPage : LuminaPage
{
    public DashboardPage(DashboardViewModel vm) : base("Dashboard", "Harbor Field", "Crew week.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Dashboard").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        Root.Add(new NVChart
        {
            Series =
            [
                new NVChartSeries
                {
                    Title = "This week",
                    Kind = NVChartSeriesKind.Bar,
                    Points =
                    [
                        new NVChartPoint { Category = "Mon", Value = 4 },
                        new NVChartPoint { Category = "Wed", Value = 7 },
                        new NVChartPoint { Category = "Fri", Value = 5 }
                    ]
                }
            ]
        });

        
AddAction("Jobs", vm.OpenJobsCommand, NVButtonVariant.Filled);        AddAction("Timesheet", vm.OpenTimesheetCommand, NVButtonVariant.Outline);
    }
}
