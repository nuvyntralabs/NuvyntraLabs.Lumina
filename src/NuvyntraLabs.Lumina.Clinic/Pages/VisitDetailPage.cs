using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class VisitDetailPage : LuminaPage
{
    public VisitDetailPage(VisitDetailViewModel vm) : base("VisitDetail", "Nuvexa Clinic", "Follow-up after lipid panel.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "VisitDetail").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Prescriptions", vm.OpenPrescriptionsCommand, NVButtonVariant.Filled);        AddAction("Documents", vm.OpenDocumentsCommand, NVButtonVariant.Outline);        AddAction("Invoice", vm.OpenInvoiceCommand, NVButtonVariant.Outline);
    }
}
