using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class VitalsPage : ContentPage
{
    public VitalsPage(VitalsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Vitals";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Detail(new ClinicModel
        {
            Title = "Vitals",
            Subtitle = "Home readings this week.",
            Items = SeedRows.For(ClinicSeed.Items, "Vitals"),
            Kind = "vitals",
            Actions =
            [
                new ClinicNav("Health profile", vm.OpenHealthProfileCommand, true, "icon_user")
            ]
        });
    }
}
