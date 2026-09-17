using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class InvoicePage : ContentPage
{
    public InvoicePage(InvoiceViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Invoice";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Invoice",
            Subtitle = "Studio invoice LM-1042.",
            Items = SeedRows.For(MarketSeed.Items, "Invoice"),
            Actions = [
            new MarketNav("Receipt", vm.OpenReceiptCommand, true),
            new MarketNav("Orders", vm.OpenOrdersCommand, false)
        ]
        });
    }
}
