using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class TimesheetPage : ContentPage
{
    public TimesheetPage(TimesheetViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Timesheet";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Form(new FieldModel
        {
            Title = "Timesheet",
            Subtitle = "Tuesday hours.",
            Items = SeedRows.For(FieldSeed.Items, "Timesheet"),
            Actions = [
            new FieldNav("Continue", vm.OpenDashboardCommand, true),
            new FieldNav("Jobs", vm.OpenJobsCommand, false)
        ]
        });
    }
}
