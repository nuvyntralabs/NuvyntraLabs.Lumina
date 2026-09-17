using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class AccountDetailPage : ContentPage
{
    public AccountDetailPage(AccountDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Current · 8841";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Detail(new BankModel
        {
            Title = "Current · 8841",
            Subtitle = "Sort 40-88-41  ·  Ada Cole",
            Items = SeedRows.For(BankSeed.Items, "AccountDetail"),
            Kind = "account",
            Actions =
            [
                new BankNav("Send from this account", vm.OpenTransferCommand, true, "icon_send"),
                new BankNav("Statements", vm.OpenStatementsCommand, false, "icon_statement"),
                new BankNav("Advice note", vm.OpenInvoiceCommand, false, "icon_statement")
            ]
        });
    }
}
