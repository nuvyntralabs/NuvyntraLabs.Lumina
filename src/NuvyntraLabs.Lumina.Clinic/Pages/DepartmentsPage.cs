using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DepartmentsPage : ContentPage
{
    public DepartmentsPage(DepartmentsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Departments";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Departments",
            Subtitle = "Floors in the Harbour building.",
            Items = SeedRows.For(ClinicSeed.Items, "Departments"),
            Kind = "departments",
            Actions = [
            new ClinicNav("Doctors", vm.OpenDoctorsCommand, true)
        ]
        });
    }
}
