using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class DashboardPage : ContentPage
{
    public DashboardPage(DashboardViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Home";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Dashboard(new BankModel
        {
            Title = "Home",
            Subtitle = "Good afternoon, Ada.",
            Items = SeedRows.For(BankSeed.Items, "Dashboard"),
            SelectedTab = "Home",
            Tabs = BankTheme.Tabs(vm.OpenHomeCommand, vm.OpenAccountsCommand, vm.OpenPayCommand, vm.OpenCardsCommand, vm.OpenMoreCommand),
            Actions =
            [
                new BankNav("Send", vm.OpenPayCommand, true, "icon_send"),
                new BankNav("Bills", vm.OpenBillsCommand, false, "icon_bill"),
                new BankNav("Cards", vm.OpenCardsCommand, false, "icon_card"),
                new BankNav("Invest", vm.OpenInvestCommand, false, "icon_chart"),
                new BankNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell"),
                new BankNav("You", vm.OpenMoreCommand, false, "icon_more"),
                new BankNav("Account", vm.OpenAccountDetailCommand, false, "icon_wallet"),
                new BankNav("Statements", vm.OpenStatementsCommand, false, "icon_statement"),
                new BankNav("Rewards", vm.OpenRewardsCommand, false, "icon_gift")
            ]
        });
    }
}
