using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class PinLockPage : LuminaPage
{
    public PinLockPage(PinLockViewModel vm) : base("PinLock", "Aether Bank", "Six digits after background.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "PinLock").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }
        Root.Add(new NVLockPad());

        
AddAction("Continue", vm.OpenDashboardCommand, NVButtonVariant.Filled);
    }
}
