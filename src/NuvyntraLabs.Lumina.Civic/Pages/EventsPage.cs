using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class EventsPage : LuminaPage
{
    public EventsPage(EventsViewModel vm) : base("Events", "Civic Pulse", "This week on the square.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Events").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("EventDetail", vm.OpenEventDetailCommand, NVButtonVariant.Filled);        AddAction("Booking", vm.OpenBookingCommand, NVButtonVariant.Outline);
    }
}
