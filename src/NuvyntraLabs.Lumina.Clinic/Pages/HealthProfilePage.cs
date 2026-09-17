using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class HealthProfilePage : ContentPage
{
    public HealthProfilePage(HealthProfileViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Health profile";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Detail(new ClinicModel
        {
            Title = "Health profile",
            Subtitle = "Ada Lovelace · 36 · London.",
            Items = SeedRows.For(ClinicSeed.Items, "HealthProfile"),
            Kind = "health",
            Actions =
            [
                new ClinicNav("Continue", vm.OpenHomeCommand, true, "icon_home"),
                new ClinicNav("Vitals", vm.OpenVitalsCommand, false, "icon_heart")
            ]
        });
    }
}
