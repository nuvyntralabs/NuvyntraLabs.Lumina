using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class MedicationsPage : ContentPage
{
    public MedicationsPage(MedicationsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Medications";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Medications",
            Subtitle = "Today's box.",
            Items = SeedRows.For(ClinicSeed.Items, "Medications"),
            Kind = "medications",
            Actions = [
            new ClinicNav("Prescriptions", vm.OpenPrescriptionsCommand, true)
        ]
        });
    }
}
