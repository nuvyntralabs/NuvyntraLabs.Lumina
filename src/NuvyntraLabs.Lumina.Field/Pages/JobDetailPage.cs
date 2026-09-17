using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class JobDetailPage : ContentPage
{
    public JobDetailPage(JobDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Job HF-204";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Job(new FieldModel
        {
            Title = "Job HF-204",
            Subtitle = "HF-204 — storm pump, Cedar Yard.",
            Items = SeedRows.For(FieldSeed.Items, "JobDetail"),
            Actions = [
            new FieldNav("Inspection", vm.OpenInspectionCommand, true),
            new FieldNav("Evidence", vm.OpenEvidenceCommand, false),
            new FieldNav("Sites", vm.OpenSitesCommand, false),
            new FieldNav("Team", vm.OpenTeamCommand, false)
        ]
        });
    }
}
