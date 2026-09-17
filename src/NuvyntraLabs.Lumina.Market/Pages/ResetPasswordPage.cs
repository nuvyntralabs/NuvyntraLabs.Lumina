using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ResetPasswordPage : ContentPage
{
    public ResetPasswordPage(ResetPasswordViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "New password";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Auth(new MarketModel
        {
            Title = "New password",
            Subtitle = "OTP then a new secret.",
            Items = SeedRows.For(MarketSeed.Items, "ResetPassword"),
            Actions = [
            new MarketNav("Sign in", vm.OpenSignInCommand, true)
        ]
        });
    }
}
