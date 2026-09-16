using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DocumentsPage : LuminaPage
{
    public DocumentsPage(DocumentsViewModel vm) : base("Documents", "Nuvexa Clinic", "Letters and PDFs.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Documents").ToList();
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
