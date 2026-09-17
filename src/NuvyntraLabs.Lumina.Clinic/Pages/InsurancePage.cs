using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InsurancePage : ContentPage
{
    public InsurancePage(InsuranceViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Insurance";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Detail(new ClinicModel
        {
            Title = "Insurance",
            Subtitle = "Nuvexa Care · member 8841.",
            Items = SeedRows.For(ClinicSeed.Items, "Insurance"),
            Kind = "insurance",
            Actions =
            [
                new ClinicNav("Account", vm.OpenSettingsCommand, true, "icon_user")
            ]
        });
    }
}
