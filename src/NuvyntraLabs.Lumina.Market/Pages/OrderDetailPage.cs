using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class OrderDetailPage : LuminaPage
{
    public OrderDetailPage(OrderDetailViewModel vm) : base("OrderDetail", "Lumina Market", "Harbour ramen + pears.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "OrderDetail").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Tracking", vm.OpenTrackingCommand, NVButtonVariant.Filled);        AddAction("Invoice", vm.OpenInvoiceCommand, NVButtonVariant.Outline);        AddAction("Receipt", vm.OpenReceiptCommand, NVButtonVariant.Outline);        AddAction("SellerChat", vm.OpenSellerChatCommand, NVButtonVariant.Outline);
    }
}
