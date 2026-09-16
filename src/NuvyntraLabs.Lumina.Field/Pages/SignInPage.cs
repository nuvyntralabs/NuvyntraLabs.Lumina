using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SignInPage : LuminaPage
{
    public SignInPage(SignInViewModel vm) : base("SignIn", "Harbor Field", "Crew gate. PIN on the van tablet.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "SignIn").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
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
