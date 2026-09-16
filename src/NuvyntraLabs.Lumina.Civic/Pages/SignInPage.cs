using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class SignInPage : LuminaPage
{
    public SignInPage(SignInViewModel vm) : base("SignIn", "Civic Pulse", "Resident pass.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "SignIn").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
Root.Add(new NVTextField { Label = "Email" });
        Root.Add(new NVTextField { Label = "Password", IsPassword = true });
        AddAction("Sign in", vm.SignInCommand);        AddAction("Continue", vm.OpenHomeCommand, NVButtonVariant.Filled);
    }
}
