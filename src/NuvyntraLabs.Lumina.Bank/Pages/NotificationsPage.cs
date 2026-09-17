using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class NotificationsPage : ContentPage
{
    public NotificationsPage(NotificationsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Alerts";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "Alerts",
            Subtitle = "Money moving on your books.",
            Items = SeedRows.For(BankSeed.Items, "Notifications"),
            Kind = "notifications",
            Actions =
            [
                new BankNav("Accounts", vm.OpenAccountsCommand, true, "icon_wallet"),
                new BankNav("Cards", vm.OpenCardsCommand, false, "icon_card")
            ]
        });
    }
}
