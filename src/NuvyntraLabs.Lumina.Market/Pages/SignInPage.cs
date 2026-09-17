using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SignInPage : ContentPage
{
    public SignInPage(SignInViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Welcome back";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Auth(new MarketModel
        {
            Title = "Welcome back",
            Subtitle = "Staff and members use the same gate.",
            Items = SeedRows.For(MarketSeed.Items, "SignIn"),
            Actions = [
            new MarketNav("Sign in", vm.SignInCommand, true),
            new MarketNav("Continue", vm.OpenHomeCommand, false),
            new MarketNav("Create account", vm.OpenSignUpCommand, false),
            new MarketNav("Forgot password?", vm.OpenForgotPasswordCommand, false)
        ]
        });
    }
}
