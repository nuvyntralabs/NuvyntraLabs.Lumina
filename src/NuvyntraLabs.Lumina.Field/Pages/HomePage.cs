using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Today";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Home(new FieldModel
        {
            Title = "Today",
            Subtitle = "Harbour district — Tuesday board.",
            Items = SeedRows.For(FieldSeed.Items, "Home"),
            SelectedTab = "Today",
            Tabs = FieldTheme.Tabs(vm.OpenHomeCommand, vm.OpenJobsCommand, vm.OpenAssetsCommand, vm.OpenOfflineQueueCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new FieldNav("Jobs", vm.OpenJobsCommand, true, "icon_jobs"),
                new FieldNav("Sites", vm.OpenSitesCommand, false, "icon_pin"),
                new FieldNav("Assets", vm.OpenAssetsCommand, false, "icon_asset"),
                new FieldNav("Queue", vm.OpenOfflineQueueCommand, false, "icon_queue"),
                new FieldNav("Scan", vm.OpenNfcScanCommand, false, "icon_nfc"),
                new FieldNav("Route", vm.OpenRouteCommand, false, "icon_route"),
                new FieldNav("Safety", vm.OpenSafetyCommand, false, "icon_safety"),
                new FieldNav("Time", vm.OpenTimesheetCommand, false, "icon_time"),
                new FieldNav("Dashboard", vm.OpenDashboardCommand, false, "icon_dash"),
                new FieldNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell"),
                new FieldNav("You", vm.OpenSettingsCommand, false, "icon_user")
            ]
        });
    }
}
