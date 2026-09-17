using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class NotificationsPage : ContentPage
{
    public NotificationsPage(NotificationsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Notifications";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Notifications",
            Subtitle = "Reminders.",
            Items = SeedRows.For(ClinicSeed.Items, "Notifications"),
            Kind = "notifications",
            Actions = [
            new ClinicNav("Visits", vm.OpenAppointmentsCommand, true)
        ]
        });
    }
}
