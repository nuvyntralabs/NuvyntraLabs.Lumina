using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class TicketDetailPage : LuminaPage
{
    public TicketDetailPage(TicketDetailViewModel vm) : base("TicketDetail", "Civic Pulse", "Day rover — QR on paper.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "TicketDetail").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Transit", vm.OpenTransitCommand, NVButtonVariant.Filled);        AddAction("Wallet", vm.OpenWalletCommand, NVButtonVariant.Outline);
    }
}
