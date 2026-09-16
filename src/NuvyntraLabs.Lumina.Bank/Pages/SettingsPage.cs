using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class SettingsPage : LuminaPage
{
    public SettingsPage(SettingsViewModel vm) : base("Settings", "Aether Bank", "Limits and flags.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Settings").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Kyc", vm.OpenKycCommand, NVButtonVariant.Filled);        AddAction("AppLock", vm.OpenAppLockCommand, NVButtonVariant.Outline);        AddAction("Support", vm.OpenSupportCommand, NVButtonVariant.Outline);
    }
}
