using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class HomePage : LuminaPage
{
    public HomePage(HomeViewModel vm) : base("Home", "Civic Pulse", "Harbour borough today.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Home").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
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

        
AddAction("Services", vm.OpenServicesCommand, NVButtonVariant.Filled);        AddAction("Transit", vm.OpenTransitCommand, NVButtonVariant.Outline);        AddAction("Events", vm.OpenEventsCommand, NVButtonVariant.Outline);        AddAction("News", vm.OpenNewsCommand, NVButtonVariant.Outline);        AddAction("Wallet", vm.OpenWalletCommand, NVButtonVariant.Outline);        AddAction("Notifications", vm.OpenNotificationsCommand, NVButtonVariant.Outline);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
