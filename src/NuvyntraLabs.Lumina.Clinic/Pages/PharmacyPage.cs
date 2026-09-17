using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class PharmacyPage : ContentPage
{
    public PharmacyPage(PharmacyViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Pharmacy";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Pharmacy",
            Subtitle = "Harbour pharmacy counter.",
            Items = SeedRows.For(ClinicSeed.Items, "Pharmacy"),
            Kind = "pharmacy",
            Actions =
            [
                new ClinicNav("Pharmacy", vm.OpenPharmacyDetailCommand, true, "icon_pill"),
                new ClinicNav("Prescriptions", vm.OpenPrescriptionsCommand, false, "icon_pill")
            ]
        });
    }
}
