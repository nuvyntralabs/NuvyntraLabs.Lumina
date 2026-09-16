using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class AddressesPage : LuminaPage
{
    public AddressesPage(AddressesViewModel vm) : base("Addresses", "Lumina Market", "Where crates land.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Addresses").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Checkout", vm.OpenCheckoutCommand, NVButtonVariant.Filled);
    }
}
