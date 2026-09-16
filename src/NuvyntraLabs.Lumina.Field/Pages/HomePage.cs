using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class HomePage : LuminaPage
{
    public HomePage(HomeViewModel vm) : base("Home", "Harbor Field", "Harbour district — Tuesday board.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Home").ToList();
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

        
AddAction("Jobs", vm.OpenJobsCommand, NVButtonVariant.Filled);        AddAction("Sites", vm.OpenSitesCommand, NVButtonVariant.Outline);        AddAction("Assets", vm.OpenAssetsCommand, NVButtonVariant.Outline);        AddAction("OfflineQueue", vm.OpenOfflineQueueCommand, NVButtonVariant.Outline);        AddAction("Dashboard", vm.OpenDashboardCommand, NVButtonVariant.Outline);        AddAction("Notifications", vm.OpenNotificationsCommand, NVButtonVariant.Outline);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
