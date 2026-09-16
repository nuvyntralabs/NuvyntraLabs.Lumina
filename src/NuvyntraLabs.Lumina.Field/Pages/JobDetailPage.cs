using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class JobDetailPage : LuminaPage
{
    public JobDetailPage(JobDetailViewModel vm) : base("JobDetail", "Harbor Field", "HF-204 — storm pump, Cedar Yard.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "JobDetail").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Inspection", vm.OpenInspectionCommand, NVButtonVariant.Filled);        AddAction("Evidence", vm.OpenEvidenceCommand, NVButtonVariant.Outline);        AddAction("Sites", vm.OpenSitesCommand, NVButtonVariant.Outline);        AddAction("Team", vm.OpenTeamCommand, NVButtonVariant.Outline);
    }
}
