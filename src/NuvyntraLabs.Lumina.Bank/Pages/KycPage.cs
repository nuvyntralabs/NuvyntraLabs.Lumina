using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class KycPage : LuminaPage
{
    public KycPage(KycViewModel vm) : base("Kyc", "Aether Bank", "Refresh your file.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Kyc").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Filled);
    }
}
