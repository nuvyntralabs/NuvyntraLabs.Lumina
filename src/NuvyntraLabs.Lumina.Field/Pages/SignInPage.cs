using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class SignInPage : ContentPage
{
    public SignInPage(SignInViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Welcome back";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Auth(new FieldModel
        {
            Title = "Welcome back",
            Subtitle = "Crew gate. PIN on the van tablet.",
            Items = SeedRows.For(FieldSeed.Items, "SignIn"),
            Actions =
            [
                new FieldNav("Sign in", vm.SignInCommand, true),
                new FieldNav("Continue as Nia", vm.OpenHomeCommand, false)
            ]
        });
    }
}
