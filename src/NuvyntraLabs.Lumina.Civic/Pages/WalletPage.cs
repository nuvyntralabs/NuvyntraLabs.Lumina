using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class WalletPage : ContentPage
{
    public WalletPage(WalletViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Wallet";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Wallet(new CivicModel
        {
            Title = "Wallet",
            Subtitle = "Civic pass + rover.",
            Items = SeedRows.For(CivicSeed.Items, "Wallet"),
            Kind = "wallet",
            SelectedTab = "Wallet",
            Tabs = CivicTheme.Tabs(vm.OpenHomeCommand, vm.OpenServicesCommand, vm.OpenTransitCommand, null, vm.OpenSettingsCommand),
            Actions =
            [
                new CivicNav("Ticket", vm.OpenTicketDetailCommand, true, "icon_ticket"),
                new CivicNav("Permits", vm.OpenPermitsCommand, false, "icon_permit"),
                new CivicNav("Help", vm.OpenHelpCommand, false, "icon_help")
            ]
        });
    }
}
