using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class AccountsPage : ContentPage
{
    public AccountsPage(AccountsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Accounts";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Accounts(new BankModel
        {
            Title = "Accounts",
            Subtitle = "Sterling and travel books.",
            Items = SeedRows.For(BankSeed.Items, "Accounts"),
            Kind = "accounts",
            SelectedTab = "Accounts",
            Tabs = BankTheme.Tabs(vm.OpenHomeCommand, null, vm.OpenPayCommand, vm.OpenCardsCommand, vm.OpenMoreCommand),
            Actions =
            [
                new BankNav("Account", vm.OpenAccountDetailCommand, true, "icon_wallet"),
                new BankNav("Statements", vm.OpenStatementsCommand, false, "icon_statement")
            ]
        });
    }
}
