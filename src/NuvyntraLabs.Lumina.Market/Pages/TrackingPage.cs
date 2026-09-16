using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class TrackingPage : LuminaPage
{
    public TrackingPage(TrackingViewModel vm) : base("Tracking", "Lumina Market", "Packed → ship → door.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Tracking").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("OrderDetail", vm.OpenOrderDetailCommand, NVButtonVariant.Filled);        AddAction("SellerChat", vm.OpenSellerChatCommand, NVButtonVariant.Outline);
    }
}
