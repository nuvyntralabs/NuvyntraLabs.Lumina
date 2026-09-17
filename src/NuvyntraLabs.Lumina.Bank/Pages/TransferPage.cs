using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class TransferPage : ContentPage
{
    public TransferPage(TransferViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Pay";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Pay(new BankModel
        {
            Title = "Pay",
            Subtitle = "Send, pay a bill, or move money abroad.",
            Items = SeedRows.For(BankSeed.Items, "Transfer"),
            Kind = "pay",
            SelectedTab = "Pay",
            Tabs = BankTheme.Tabs(vm.OpenHomeCommand, vm.OpenAccountsCommand, null, vm.OpenCardsCommand, vm.OpenMoreCommand),
            Actions =
            [
                new BankNav("Payees", vm.OpenPayeesCommand, true, "icon_people"),
                new BankNav("Bills", vm.OpenBillsCommand, false, "icon_bill"),
                new BankNav("Beneficiaries", vm.OpenBeneficiariesCommand, false, "icon_globe")
            ]
        });
    }
}
