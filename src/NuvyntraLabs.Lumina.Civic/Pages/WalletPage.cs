using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class WalletPage : LuminaPage
{
    public WalletPage(WalletViewModel vm) : base("Wallet", "Civic Pulse", "Civic pass + rover.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Wallet").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("TicketDetail", vm.OpenTicketDetailCommand, NVButtonVariant.Filled);        AddAction("Permits", vm.OpenPermitsCommand, NVButtonVariant.Outline);
    }
}
