using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class HomePage : LuminaPage
{
    public HomePage(HomeViewModel vm) : base("Home", "Nuvexa Clinic", "Today at Nuvexa Clinic.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Home").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
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

        
AddAction("Appointments", vm.OpenAppointmentsCommand, NVButtonVariant.Filled);        AddAction("Doctors", vm.OpenDoctorsCommand, NVButtonVariant.Outline);        AddAction("Pharmacy", vm.OpenPharmacyCommand, NVButtonVariant.Outline);        AddAction("LabResults", vm.OpenLabResultsCommand, NVButtonVariant.Outline);        AddAction("Inbox", vm.OpenInboxCommand, NVButtonVariant.Outline);        AddAction("Notifications", vm.OpenNotificationsCommand, NVButtonVariant.Outline);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
