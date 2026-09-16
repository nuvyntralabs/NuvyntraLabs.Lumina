using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SignInPage : LuminaPage
{
    public SignInPage(SignInViewModel vm) : base("SignIn", "Lumina Market", "Staff and members use the same gate.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "SignIn").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
Root.Add(new NVTextField { Label = "Email" });
        Root.Add(new NVTextField { Label = "Password", IsPassword = true });
        AddAction("Sign in", vm.SignInCommand);        AddAction("Continue", vm.OpenHomeCommand, NVButtonVariant.Filled);        AddAction("SignUp", vm.OpenSignUpCommand, NVButtonVariant.Outline);        AddAction("ForgotPassword", vm.OpenForgotPasswordCommand, NVButtonVariant.Outline);
    }
}
