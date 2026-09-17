using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ReceiptPage : ContentPage
{
    public ReceiptPage(ReceiptViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Receipt";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Receipt",
            Subtitle = "Thermal-style ticket.",
            Items = SeedRows.For(MarketSeed.Items, "Receipt"),
            Actions = [
            new MarketNav("Orders", vm.OpenOrdersCommand, true)
        ]
        });
    }
}
