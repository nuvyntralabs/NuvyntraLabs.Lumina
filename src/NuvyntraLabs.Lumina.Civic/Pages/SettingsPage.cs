using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "You";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Account(new CivicModel
        {
            Title = "You",
            Subtitle = "Alerts and theme.",
            Items = SeedRows.For(CivicSeed.Items, "Settings"),
            Kind = "account",
            SelectedTab = "You",
            Tabs = CivicTheme.Tabs(vm.OpenHomeCommand, vm.OpenServicesCommand, vm.OpenTransitCommand, vm.OpenWalletCommand, null),
            Actions =
            [
                new CivicNav("Offices", vm.OpenOfficesCommand, false, "icon_office", "Town hall and library"),
                new CivicNav("People", vm.OpenPeopleCommand, false, "icon_people", "Ward and waste desk"),
                new CivicNav("Permits", vm.OpenPermitsCommand, false, "icon_permit", "Bay and skip paper"),
                new CivicNav("News", vm.OpenNewsCommand, false, "icon_news", "Borough notes"),
                new CivicNav("Events", vm.OpenEventsCommand, false, "icon_calendar", "This week on the square"),
                new CivicNav("Wallet", vm.OpenWalletCommand, false, "icon_wallet", "Pass and rover"),
                new CivicNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell", "Bin and bus pings"),
                new CivicNav("Help", vm.OpenHelpCommand, false, "icon_help", "How to use Pulse"),
                new CivicNav("Faq", vm.OpenFaqCommand, false, "icon_help", "What residents ask"),
                new CivicNav("About", vm.OpenAboutCommand, true, "icon_council", "Harbour borough"),
                new CivicNav("What's new", vm.OpenWhatsNewCommand, false, "icon_news", "1.0 prototype notes")
            ]
        });
    }
}
