using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "You";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Account(new FieldModel
        {
            Title = "You",
            Subtitle = "Keep-awake, offline, pins.",
            Items = SeedRows.For(FieldSeed.Items, "Settings"),
            Kind = "account",
            SelectedTab = "You",
            Tabs = FieldTheme.Tabs(vm.OpenHomeCommand, vm.OpenJobsCommand, vm.OpenAssetsCommand, vm.OpenOfflineQueueCommand, null),
            Actions =
            [
                new FieldNav("Dashboard", vm.OpenDashboardCommand, true, "icon_dash", "Crew week"),
                new FieldNav("Jobs", vm.OpenJobsCommand, false, "icon_jobs", "Assigned board"),
                new FieldNav("Timesheet", vm.OpenTimesheetCommand, false, "icon_time", "Hours on HF jobs"),
                new FieldNav("Route", vm.OpenRouteCommand, false, "icon_route", "Cedar to desk"),
                new FieldNav("Sites", vm.OpenSitesCommand, false, "icon_pin", "Yards on the fence"),
                new FieldNav("Safety", vm.OpenSafetyCommand, false, "icon_safety", "Permit and gas"),
                new FieldNav("Checklist", vm.OpenChecklistCommand, false, "icon_check", "PPE and lockout"),
                new FieldNav("Files", vm.OpenFilesCommand, false, "icon_file", "Plans and PDFs"),
                new FieldNav("Printers", vm.OpenPrintersCommand, false, "icon_print", "Zebra and desk"),
                new FieldNav("Team", vm.OpenTeamCommand, false, "icon_team", "Van chat"),
                new FieldNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell", "SLA and fence"),
                new FieldNav("Queue", vm.OpenOfflineQueueCommand, false, "icon_queue", "Photos waiting")
            ]
        });
    }
}
