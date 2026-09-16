using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SettingsPage : LuminaPage
{
    public SettingsPage(SettingsViewModel vm) : base("Settings", "Lumina Market", "Theme, flags, lock.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "Settings").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Help", vm.OpenHelpCommand, NVButtonVariant.Filled);        AddAction("Subscription", vm.OpenSubscriptionCommand, NVButtonVariant.Outline);        AddAction("StoreLocator", vm.OpenStoreLocatorCommand, NVButtonVariant.Outline);
    }
}
