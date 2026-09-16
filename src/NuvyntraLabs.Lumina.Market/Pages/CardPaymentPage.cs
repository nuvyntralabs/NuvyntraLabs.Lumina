using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CardPaymentPage : LuminaPage
{
    public CardPaymentPage(CardPaymentViewModel vm) : base("CardPayment", "Lumina Market", "Masked PAN on warm paper.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "CardPayment").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("PaymentResult", vm.OpenPaymentResultCommand, NVButtonVariant.Filled);        AddAction("SavedCards", vm.OpenSavedCardsCommand, NVButtonVariant.Outline);
    }
}
