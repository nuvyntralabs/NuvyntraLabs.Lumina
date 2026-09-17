using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class LabDetailPage : ContentPage
{
    public LabDetailPage(LabDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Lipid panel";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Detail(new ClinicModel
        {
            Title = "Lipid panel",
            Subtitle = "Lipid panel — 12 Sep 2026.",
            Items = SeedRows.For(ClinicSeed.Items, "LabDetail"),
            Kind = "labs",
            Actions =
            [
                new ClinicNav("Visit", vm.OpenVisitDetailCommand, true, "icon_clinic"),
                new ClinicNav("Documents", vm.OpenDocumentsCommand, false, "icon_doc")
            ]
        });
    }
}
