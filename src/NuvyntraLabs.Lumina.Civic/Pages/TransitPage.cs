using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class TransitPage : LuminaPage
{
    public TransitPage(TransitViewModel vm) : base("Transit", "Civic Pulse", "Live-looking times, static clock.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Transit").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("TicketDetail", vm.OpenTicketDetailCommand, NVButtonVariant.Filled);        AddAction("Booking", vm.OpenBookingCommand, NVButtonVariant.Outline);
    }
}
