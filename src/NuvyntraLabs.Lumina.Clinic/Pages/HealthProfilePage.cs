using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class HealthProfilePage : LuminaPage
{
    public HealthProfilePage(HealthProfileViewModel vm) : base("HealthProfile", "Nuvexa Clinic", "Ada Lovelace · 36 · London.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "HealthProfile").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }
        Root.Add(new NVGauge { Value = 72 });
        Root.Add(new NVAvatar { Initials = "AL", StatusOn = true });

        
AddAction("Home", vm.OpenHomeCommand, NVButtonVariant.Filled);        AddAction("Vitals", vm.OpenVitalsCommand, NVButtonVariant.Outline);
    }
}
