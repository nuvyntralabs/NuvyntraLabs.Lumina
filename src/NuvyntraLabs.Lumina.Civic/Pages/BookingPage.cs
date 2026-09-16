using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class BookingPage : LuminaPage
{
    public BookingPage(BookingViewModel vm) : base("Booking", "Civic Pulse", "Reserve a desk or a court.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Booking").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }
        Root.Add(new NVCalendar());

        
AddAction("Events", vm.OpenEventsCommand, NVButtonVariant.Filled);        AddAction("Offices", vm.OpenOfficesCommand, NVButtonVariant.Outline);
    }
}
