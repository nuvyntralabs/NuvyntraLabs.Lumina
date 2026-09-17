using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class ServicesPage : ContentPage
{
    public ServicesPage(ServicesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Services";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Services(new CivicModel
        {
            Title = "Services",
            Subtitle = "Requests the desk still owns.",
            Items = SeedRows.For(CivicSeed.Items, "Services"),
            Kind = "services",
            SelectedTab = "Services",
            Tabs = CivicTheme.Tabs(vm.OpenHomeCommand, null, vm.OpenTransitCommand, vm.OpenWalletCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new CivicNav("Request", vm.OpenRequestDetailCommand, true, "icon_services"),
                new CivicNav("Permits", vm.OpenPermitsCommand, false, "icon_permit"),
                new CivicNav("Offices", vm.OpenOfficesCommand, false, "icon_office"),
                new CivicNav("Booking", vm.OpenBookingCommand, false, "icon_calendar")
            ]
        });
    }
}
