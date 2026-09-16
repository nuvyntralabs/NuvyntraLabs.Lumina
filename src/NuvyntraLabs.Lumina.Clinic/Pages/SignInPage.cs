using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class SignInPage : LuminaPage
{
    public SignInPage(SignInViewModel vm) : base("SignIn", "Nuvexa Clinic", "Patients and clinicians.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "SignIn").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
Root.Add(new NVTextField { Label = "Email" });
        Root.Add(new NVTextField { Label = "Password", IsPassword = true });
        AddAction("Sign in", vm.SignInCommand);        AddAction("Continue", vm.OpenHomeCommand, NVButtonVariant.Filled);        AddAction("HealthProfile", vm.OpenHealthProfileCommand, NVButtonVariant.Outline);
    }
}
