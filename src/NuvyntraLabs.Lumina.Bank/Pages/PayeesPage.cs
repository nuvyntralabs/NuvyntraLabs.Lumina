using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class PayeesPage : LuminaPage
{
    public PayeesPage(PayeesViewModel vm) : base("Payees", "Aether Bank", "Trusted names.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Payees").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Transfer", vm.OpenTransferCommand, NVButtonVariant.Filled);        AddAction("Beneficiaries", vm.OpenBeneficiariesCommand, NVButtonVariant.Outline);
    }
}
