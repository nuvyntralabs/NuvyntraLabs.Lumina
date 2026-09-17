using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class SignInPage : ContentPage
{
    public SignInPage(SignInViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Welcome back";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Auth(new ClinicModel
        {
            Title = "Welcome back",
            Subtitle = "Patients and clinicians use the same gate.",
            Items = SeedRows.For(ClinicSeed.Items, "SignIn"),
            Actions =
            [
                new ClinicNav("Continue", vm.SignInCommand, true),
                new ClinicNav("Skip to home", vm.OpenHomeCommand, false),
                new ClinicNav("Health profile", vm.OpenHealthProfileCommand, false)
            ]
        });
    }
}
