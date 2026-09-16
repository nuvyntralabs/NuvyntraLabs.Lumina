using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ForgotPasswordPage : LuminaPage
{
    public ForgotPasswordPage(ForgotPasswordViewModel vm) : base("ForgotPassword", "Lumina Market", "Send a reset link to the inbox.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "ForgotPassword").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("ResetPassword", vm.OpenResetPasswordCommand, NVButtonVariant.Filled);        AddAction("SignIn", vm.OpenSignInCommand, NVButtonVariant.Outline);
    }
}
