using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class OfflineQueuePage : ContentPage
{
    public OfflineQueuePage(OfflineQueueViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Queue";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Queue(new FieldModel
        {
            Title = "Queue",
            Subtitle = "Waiting for real internet.",
            Items = SeedRows.For(FieldSeed.Items, "OfflineQueue"),
            Kind = "queue",
            SelectedTab = "Queue",
            Tabs = FieldTheme.Tabs(vm.OpenHomeCommand, vm.OpenJobsCommand, vm.OpenAssetsCommand, null, vm.OpenSettingsCommand),
            Actions =
            [
                new FieldNav("Conflicts", vm.OpenConflictsCommand, true, "icon_conflict"),
                new FieldNav("Evidence", vm.OpenEvidenceCommand, false, "icon_camera")
            ]
        });
    }
}
