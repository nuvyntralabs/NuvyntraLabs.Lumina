using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class JobsPage : ContentPage
{
    public JobsPage(JobsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Jobs";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Jobs(new FieldModel
        {
            Title = "Jobs",
            Subtitle = "Assigned work.",
            Items = SeedRows.For(FieldSeed.Items, "Jobs"),
            Kind = "jobs",
            SelectedTab = "Jobs",
            Tabs = FieldTheme.Tabs(vm.OpenHomeCommand, null, vm.OpenAssetsCommand, vm.OpenOfflineQueueCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new FieldNav("Job", vm.OpenJobDetailCommand, true, "icon_jobs"),
                new FieldNav("Route", vm.OpenRouteCommand, false, "icon_route")
            ]
        });
    }
}
