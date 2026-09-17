using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class SettingsPage : ContentPage
{
    public SettingsPage(SettingsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "More";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.More(new BankModel
        {
            Title = "More",
            Subtitle = "You, money, and security.",
            Items = SeedRows.For(BankSeed.Items, "Settings"),
            Kind = "more",
            SelectedTab = "More",
            Tabs = BankTheme.Tabs(vm.OpenHomeCommand, vm.OpenAccountsCommand, vm.OpenPayCommand, vm.OpenCardsCommand, null),
            Actions =
            [
                new BankNav("Accounts", vm.OpenAccountsCommand, false, "icon_wallet", "Current, savings, travel"),
                new BankNav("Cards", vm.OpenCardsCommand, false, "icon_card", "Freeze, limits, PIN"),
                new BankNav("Send", vm.OpenPayCommand, false, "icon_send", "UK Faster Payments"),
                new BankNav("Bills", vm.OpenBillsCommand, false, "icon_bill", "Council and utilities"),
                new BankNav("Payees", vm.OpenPayeesCommand, false, "icon_people", "Saved UK payees"),
                new BankNav("Beneficiaries", vm.OpenBeneficiariesCommand, false, "icon_globe", "International"),
                new BankNav("Invest", vm.OpenInvestCommand, false, "icon_chart", "Wealth sleeves"),
                new BankNav("Loans", vm.OpenLoansCommand, false, "icon_loan", "Credit and overdraft"),
                new BankNav("Rewards", vm.OpenRewardsCommand, false, "icon_gift", "Aurora points"),
                new BankNav("Statements", vm.OpenStatementsCommand, false, "icon_statement", "Monthly PDFs"),
                new BankNav("Invoice", vm.OpenInvoiceCommand, false, "icon_statement", "FX advice notes"),
                new BankNav("Locked", vm.OpenAppLockCommand, false, "icon_shield", "PIN, Face ID, screen guard"),
                new BankNav("Verify", vm.OpenKycCommand, true, "icon_kyc", "Refresh your file"),
                new BankNav("Support", vm.OpenSupportCommand, false, "icon_support", "Secure inbox"),
                new BankNav("Alerts", vm.OpenNotificationsCommand, false, "icon_bell", "Money moving")
            ]
        });
    }
}
