using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class TransitPage : ContentPage
{
    public TransitPage(TransitViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Transit";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Transit(new CivicModel
        {
            Title = "Transit",
            Subtitle = "Live-looking times, static clock.",
            Items = SeedRows.For(CivicSeed.Items, "Transit"),
            Kind = "transit",
            SelectedTab = "Transit",
            Tabs = CivicTheme.Tabs(vm.OpenHomeCommand, vm.OpenServicesCommand, null, vm.OpenWalletCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new CivicNav("Ticket", vm.OpenTicketDetailCommand, true, "icon_ticket"),
                new CivicNav("Booking", vm.OpenBookingCommand, false, "icon_calendar")
            ]
        });
    }
}
