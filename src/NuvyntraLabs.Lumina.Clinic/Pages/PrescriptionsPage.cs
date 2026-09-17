using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class PrescriptionsPage : ContentPage
{
    public PrescriptionsPage(PrescriptionsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Prescriptions";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Prescriptions",
            Subtitle = "Active scripts.",
            Items = SeedRows.For(ClinicSeed.Items, "Prescriptions"),
            Kind = "prescriptions",
            Actions = [
            new ClinicNav("Pharmacy", vm.OpenPharmacyCommand, true),
            new ClinicNav("Visit", vm.OpenVisitDetailCommand, false)
        ]
        });
    }
}
