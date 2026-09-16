using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class BookingPage : LuminaPage
{
    public BookingPage(BookingViewModel vm) : base("Booking", "Nuvexa Clinic", "Pick a slot on the calendar.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Booking").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }
        Root.Add(new NVCalendar());

        
AddAction("Appointments", vm.OpenAppointmentsCommand, NVButtonVariant.Filled);        AddAction("Doctors", vm.OpenDoctorsCommand, NVButtonVariant.Outline);
    }
}
