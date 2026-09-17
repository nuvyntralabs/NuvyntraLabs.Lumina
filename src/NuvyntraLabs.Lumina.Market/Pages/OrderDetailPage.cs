using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class OrderDetailPage : ContentPage
{
    public OrderDetailPage(OrderDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Order detail";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.List(new MarketModel
        {
            Title = "Order detail",
            Subtitle = "Harbour ramen + pears.",
            Items = SeedRows.For(MarketSeed.Items, "OrderDetail"),
            Actions = [
            new MarketNav("Track order", vm.OpenTrackingCommand, true),
            new MarketNav("Invoice", vm.OpenInvoiceCommand, false),
            new MarketNav("Receipt", vm.OpenReceiptCommand, false),
            new MarketNav("Message kitchen", vm.OpenSellerChatCommand, false)
        ]
        });
    }
}
