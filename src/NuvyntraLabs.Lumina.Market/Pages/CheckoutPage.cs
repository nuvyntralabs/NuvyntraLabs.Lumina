using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CheckoutPage : LuminaPage
{
    public CheckoutPage(CheckoutViewModel vm) : base("Checkout", "Lumina Market", "Address plus slot.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Checkout").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("CardPayment", vm.OpenCardPaymentCommand, NVButtonVariant.Filled);        AddAction("Addresses", vm.OpenAddressesCommand, NVButtonVariant.Outline);
    }
}
