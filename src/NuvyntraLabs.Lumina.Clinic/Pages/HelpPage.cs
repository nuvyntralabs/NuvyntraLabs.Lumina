using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class HelpPage : ContentPage
{
    public HelpPage(HelpViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Help";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Help",
            Subtitle = "Desk and after-hours.",
            Items = SeedRows.For(ClinicSeed.Items, "Help"),
            Kind = "help",
            Actions =
            [
                new ClinicNav("Faq", vm.OpenFaqCommand, true, "icon_help"),
                new ClinicNav("You", vm.OpenSettingsCommand, false, "icon_user")
            ]
        });
    }
}
