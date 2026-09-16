using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class AppLockPage : LuminaPage
{
    public AppLockPage(AppLockViewModel vm) : base("AppLock", "Aether Bank", "Timer, Face ID, screenshot guard.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "AppLock").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("PinLock", vm.OpenPinLockCommand, NVButtonVariant.Filled);        AddAction("Settings", vm.OpenSettingsCommand, NVButtonVariant.Outline);
    }
}
