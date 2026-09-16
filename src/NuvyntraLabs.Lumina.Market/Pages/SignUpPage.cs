using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SignUpPage : LuminaPage
{
    public SignUpPage(SignUpViewModel vm) : base("SignUp", "Lumina Market", "Create a Market account.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "SignUp").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("SignIn", vm.OpenSignInCommand, NVButtonVariant.Filled);        AddAction("ProfileSetup", vm.OpenProfileSetupCommand, NVButtonVariant.Outline);
    }
}
