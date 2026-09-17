using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class SignInPage : ContentPage
{
    public SignInPage(SignInViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Welcome back";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Auth(new CivicModel
        {
            Title = "Welcome back",
            Subtitle = "Sign in with your resident pass.",
            Items = SeedRows.For(CivicSeed.Items, "SignIn"),
            Actions =
            [
                new CivicNav("Sign in", vm.SignInCommand, true),
                new CivicNav("Continue as Ada", vm.OpenHomeCommand, false)
            ]
        });
    }
}
