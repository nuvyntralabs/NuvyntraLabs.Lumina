using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class NotificationsPage : LuminaPage
{
    public NotificationsPage(NotificationsViewModel vm) : base("Notifications", "Aether Bank", "Money moving.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Notifications").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Accounts", vm.OpenAccountsCommand, NVButtonVariant.Filled);        AddAction("Cards", vm.OpenCardsCommand, NVButtonVariant.Outline);
    }
}
