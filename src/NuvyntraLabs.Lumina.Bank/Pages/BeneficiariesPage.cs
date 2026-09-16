using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class BeneficiariesPage : LuminaPage
{
    public BeneficiariesPage(BeneficiariesViewModel vm) : base("Beneficiaries", "Aether Bank", "International.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Beneficiaries").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Payees", vm.OpenPayeesCommand, NVButtonVariant.Filled);        AddAction("Transfer", vm.OpenTransferCommand, NVButtonVariant.Outline);
    }
}
