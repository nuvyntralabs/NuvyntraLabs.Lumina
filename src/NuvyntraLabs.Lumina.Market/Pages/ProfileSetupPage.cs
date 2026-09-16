using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ProfileSetupPage : LuminaPage
{
    public ProfileSetupPage(ProfileSetupViewModel vm) : base("ProfileSetup", "Lumina Market", "Avatar, kitchen name, delivery default.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "ProfileSetup").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Home", vm.OpenHomeCommand, NVButtonVariant.Filled);
    }
}
