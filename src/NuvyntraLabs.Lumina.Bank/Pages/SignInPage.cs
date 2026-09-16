using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class SignInPage : LuminaPage
{
    public SignInPage(SignInViewModel vm) : base("SignIn", "Aether Bank", "Member number or email.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "SignIn").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
Root.Add(new NVTextField { Label = "Email" });
        Root.Add(new NVTextField { Label = "Password", IsPassword = true });
        AddAction("Sign in", vm.SignInCommand);        AddAction("PinLock", vm.OpenPinLockCommand, NVButtonVariant.Filled);
    }
}
