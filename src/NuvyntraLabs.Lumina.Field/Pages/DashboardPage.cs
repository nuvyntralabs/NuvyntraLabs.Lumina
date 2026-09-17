using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class DashboardPage : ContentPage
{
    public DashboardPage(DashboardViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Home";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Home",
            Subtitle = "Crew week.",
            Items = SeedRows.For(FieldSeed.Items, "Dashboard"),
            Kind = "dashboard",
            Actions = [
            new FieldNav("Jobs", vm.OpenJobsCommand, true),
            new FieldNav("Time", vm.OpenTimesheetCommand, false)
        ]
        });
    }
}
