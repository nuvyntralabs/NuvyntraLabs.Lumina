using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class PaymentResultPage : LuminaPage
{
    public PaymentResultPage(PaymentResultViewModel vm) : base("PaymentResult", "Lumina Market", "Paid. Courier is packing.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "PaymentResult").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Tracking", vm.OpenTrackingCommand, NVButtonVariant.Filled);        AddAction("Orders", vm.OpenOrdersCommand, NVButtonVariant.Outline);        AddAction("Receipt", vm.OpenReceiptCommand, NVButtonVariant.Outline);
    }
}
