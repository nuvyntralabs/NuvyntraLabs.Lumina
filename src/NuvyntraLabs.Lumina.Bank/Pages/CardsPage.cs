using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class CardsPage : LuminaPage
{
    public CardsPage(CardsViewModel vm) : base("Cards", "Aether Bank", "Plastic and metal.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Cards").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("CardDetail", vm.OpenCardDetailCommand, NVButtonVariant.Filled);
    }
}
