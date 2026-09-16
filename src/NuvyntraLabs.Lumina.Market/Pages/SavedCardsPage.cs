using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SavedCardsPage : LuminaPage
{
    public SavedCardsPage(SavedCardsViewModel vm) : base("SavedCards", "Lumina Market", "Instruments on file.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "SavedCards").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("CardPayment", vm.OpenCardPaymentCommand, NVButtonVariant.Filled);
    }
}
