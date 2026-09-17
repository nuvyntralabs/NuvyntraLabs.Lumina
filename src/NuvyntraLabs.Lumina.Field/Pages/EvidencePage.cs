using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class EvidencePage : ContentPage
{
    public EvidencePage(EvidenceViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Evidence";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Form(new FieldModel
        {
            Title = "Evidence",
            Subtitle = "Photos queued for upload.",
            Items = SeedRows.For(FieldSeed.Items, "Evidence"),
            Kind = "evidence",
            Actions = [
            new FieldNav("Inspection", vm.OpenInspectionCommand, true),
            new FieldNav("Queue", vm.OpenOfflineQueueCommand, false)
        ]
        });
    }
}
