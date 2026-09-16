using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class OfficesPage : LuminaPage
{
    public OfficesPage(OfficesViewModel vm) : base("Offices", "Civic Pulse", "Counters still open.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "Offices").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Booking", vm.OpenBookingCommand, NVButtonVariant.Filled);        AddAction("People", vm.OpenPeopleCommand, NVButtonVariant.Outline);
    }
}
