using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InvoicePage : LuminaPage
{
    public InvoicePage(InvoiceViewModel vm) : base("Invoice", "Nuvexa Clinic", "Visit 12 Sep.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Invoice").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("VisitDetail", vm.OpenVisitDetailCommand, NVButtonVariant.Filled);
    }
}
