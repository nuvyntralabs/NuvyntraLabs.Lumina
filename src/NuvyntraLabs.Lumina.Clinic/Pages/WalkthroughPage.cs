using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class WalkthroughPage : ContentPage
{
    public WalkthroughPage(WalkthroughViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Welcome";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Walkthrough(new ClinicModel
        {
            Title = "Welcome",
            Subtitle = "Care without the clipboard pile.",
            Items = SeedRows.For(ClinicSeed.Items, "Walkthrough"),
            Actions =
            [
                new ClinicNav("Get started", vm.OpenSignInCommand, true)
            ]
        });
    }
}
