using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class NotificationsPage : ContentPage
{
    public NotificationsPage(NotificationsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Notifications";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Notifications",
            Subtitle = "Dispatch.",
            Items = SeedRows.For(FieldSeed.Items, "Notifications"),
            Kind = "notifications",
            Actions = [
            new FieldNav("Jobs", vm.OpenJobsCommand, true)
        ]
        });
    }
}
