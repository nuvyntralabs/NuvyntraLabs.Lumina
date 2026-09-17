using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class PharmacyDetailPage : ContentPage
{
    public PharmacyDetailPage(PharmacyDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Atorvastatin";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Detail(new ClinicModel
        {
            Title = "Atorvastatin",
            Subtitle = "Atorvastatin 10 mg film-coated.",
            Items = SeedRows.For(ClinicSeed.Items, "PharmacyDetail"),
            Kind = "pharmacy",
            Actions =
            [
                new ClinicNav("Pharmacy", vm.OpenPharmacyCommand, true, "icon_pill")
            ]
        });
    }
}
