using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Home";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Home(new CivicModel
        {
            Title = "Home",
            Subtitle = "Harbour borough today.",
            Items = SeedRows.For(CivicSeed.Items, "Home"),
            SelectedTab = "Home",
            Tabs = CivicTheme.Tabs(vm.OpenHomeCommand, vm.OpenServicesCommand, vm.OpenTransitCommand, vm.OpenWalletCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new CivicNav("Services", vm.OpenServicesCommand, true, "icon_services"),
                new CivicNav("Transit", vm.OpenTransitCommand, false, "icon_transit"),
                new CivicNav("Events", vm.OpenEventsCommand, false, "icon_calendar"),
                new CivicNav("News", vm.OpenNewsCommand, false, "icon_news"),
                new CivicNav("Wallet", vm.OpenWalletCommand, false, "icon_wallet"),
                new CivicNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell"),
                new CivicNav("You", vm.OpenSettingsCommand, false, "icon_user")
            ]
        });
    }
}
