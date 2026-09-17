using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class StatementsPage : ContentPage
{
    public StatementsPage(StatementsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Statements";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "Statements",
            Subtitle = "Monthly PDFs for current.",
            Items = SeedRows.For(BankSeed.Items, "Statements"),
            Kind = "statements",
            Actions =
            [
                new BankNav("Open account", vm.OpenAccountDetailCommand, true, "icon_wallet"),
                new BankNav("Advice note", vm.OpenInvoiceCommand, false, "icon_statement")
            ]
        });
    }
}
