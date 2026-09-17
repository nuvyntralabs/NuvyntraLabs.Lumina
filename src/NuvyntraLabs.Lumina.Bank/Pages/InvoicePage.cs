using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class InvoicePage : ContentPage
{
    public InvoicePage(InvoiceViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Advice note";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Detail(new BankModel
        {
            Title = "Advice note",
            Subtitle = "FX 12 Sep · current · 8841",
            Items = SeedRows.For(BankSeed.Items, "Invoice"),
            Kind = "invoice",
            Actions =
            [
                new BankNav("Open account", vm.OpenAccountDetailCommand, true, "icon_wallet")
            ]
        });
    }
}
