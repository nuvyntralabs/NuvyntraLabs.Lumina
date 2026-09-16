using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class EventDetailPage : LuminaPage
{
    public EventDetailPage(EventDetailViewModel vm) : base("EventDetail", "Civic Pulse", "Harbour night market.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "EventDetail").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Events", vm.OpenEventsCommand, NVButtonVariant.Filled);        AddAction("Offices", vm.OpenOfficesCommand, NVButtonVariant.Outline);
    }
}
