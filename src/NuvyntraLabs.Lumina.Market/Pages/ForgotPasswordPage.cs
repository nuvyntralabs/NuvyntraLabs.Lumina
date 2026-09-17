using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage(ForgotPasswordViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Forgot password";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Auth(new MarketModel
        {
            Title = "Forgot password",
            Subtitle = "Send a reset link to the inbox.",
            Items = SeedRows.For(MarketSeed.Items, "ForgotPassword"),
            Actions = [
            new MarketNav("Save password", vm.OpenResetPasswordCommand, true),
            new MarketNav("Sign in", vm.OpenSignInCommand, false)
        ]
        });
    }
}
