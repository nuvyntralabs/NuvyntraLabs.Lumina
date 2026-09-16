using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class DashboardPage : LuminaPage
{
    public DashboardPage(DashboardViewModel vm) : base("Dashboard", "Aether Bank", "Good afternoon, Ada.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Dashboard").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
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

        
AddAction("Accounts", vm.OpenAccountsCommand, NVButtonVariant.Filled);        AddAction("Cards", vm.OpenCardsCommand, NVButtonVariant.Outline);        AddAction("Transfer", vm.OpenTransferCommand, NVButtonVariant.Outline);        AddAction("Invest", vm.OpenInvestCommand, NVButtonVariant.Outline);        AddAction("Notifications", vm.OpenNotificationsCommand, NVButtonVariant.Outline);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
