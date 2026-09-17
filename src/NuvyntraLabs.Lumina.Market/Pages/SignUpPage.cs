using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SignUpPage : ContentPage
{
    public SignUpPage(SignUpViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Create your account";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Auth(new MarketModel
        {
            Title = "Create your account",
            Subtitle = "Create a Market account.",
            Items = SeedRows.For(MarketSeed.Items, "SignUp"),
            Actions = [
            new MarketNav("Sign in", vm.OpenSignInCommand, true),
            new MarketNav("Save profile", vm.OpenProfileSetupCommand, false)
        ]
        });
    }
}
