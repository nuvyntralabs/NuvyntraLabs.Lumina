using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class PaymentResultPage : ContentPage
{
    public PaymentResultPage(PaymentResultViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Order placed";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Result(new MarketModel
        {
            Title = "Order placed",
            Subtitle = "Paid. Courier is packing.",
            Items = SeedRows.For(MarketSeed.Items, "PaymentResult"),
            Actions = [
            new MarketNav("Track order", vm.OpenTrackingCommand, true),
            new MarketNav("Orders", vm.OpenOrdersCommand, false),
            new MarketNav("Receipt", vm.OpenReceiptCommand, false)
        ]
        });
    }
}
