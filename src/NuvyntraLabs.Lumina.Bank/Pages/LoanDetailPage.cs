using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class LoanDetailPage : LuminaPage
{
    public LoanDetailPage(LoanDetailViewModel vm) : base("LoanDetail", "Aether Bank", "Studio loan — 4.2% APR.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "LoanDetail").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Loans", vm.OpenLoansCommand, NVButtonVariant.Filled);        AddAction("Transfer", vm.OpenTransferCommand, NVButtonVariant.Outline);
    }
}
