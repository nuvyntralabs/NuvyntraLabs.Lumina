using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class CardDetailPage : LuminaPage
{
    public CardDetailPage(CardDetailViewModel vm) : base("CardDetail", "Aether Bank", "Aurora debit ··4418.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "CardDetail").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Cards", vm.OpenCardsCommand, NVButtonVariant.Filled);        AddAction("AppLock", vm.OpenAppLockCommand, NVButtonVariant.Outline);
    }
}
