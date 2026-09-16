using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class OrdersPage : LuminaPage
{
    public OrdersPage(OrdersViewModel vm) : base("Orders", "Lumina Market", "Open tickets.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Orders").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("OrderDetail", vm.OpenOrderDetailCommand, NVButtonVariant.Filled);        AddAction("Tracking", vm.OpenTrackingCommand, NVButtonVariant.Outline);
    }
}
