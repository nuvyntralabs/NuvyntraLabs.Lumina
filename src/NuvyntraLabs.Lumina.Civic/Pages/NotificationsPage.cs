using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class NotificationsPage : ContentPage
{
    public NotificationsPage(NotificationsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Notifications";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "Notifications",
            Subtitle = "Borough pings.",
            Items = SeedRows.For(CivicSeed.Items, "Notifications"),
            Kind = "notifications",
            Actions =
            [
                new CivicNav("Transit", vm.OpenTransitCommand, true, "icon_transit"),
                new CivicNav("Services", vm.OpenServicesCommand, false, "icon_services", "Open a request")
            ]
        });
    }
}
