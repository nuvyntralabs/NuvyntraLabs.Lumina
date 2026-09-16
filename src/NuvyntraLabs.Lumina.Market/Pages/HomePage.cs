using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class HomePage : LuminaPage
{
    public HomePage(HomeViewModel vm) : base("Home", "Lumina Market", "Today at Harbour Market.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Home").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
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

        
AddAction("Categories", vm.OpenCategoriesCommand, NVButtonVariant.Filled);        AddAction("Catalog", vm.OpenCatalogCommand, NVButtonVariant.Outline);        AddAction("Search", vm.OpenSearchCommand, NVButtonVariant.Outline);        AddAction("Cart", vm.OpenCartCommand, NVButtonVariant.Outline);        AddAction("Orders", vm.OpenOrdersCommand, NVButtonVariant.Outline);        AddAction("Notifications", vm.OpenNotificationsCommand, NVButtonVariant.Outline);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
