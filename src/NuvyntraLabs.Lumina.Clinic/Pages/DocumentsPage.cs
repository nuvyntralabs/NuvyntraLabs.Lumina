using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class DocumentsPage : ContentPage
{
    public DocumentsPage(DocumentsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Documents";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Documents",
            Subtitle = "Letters and PDFs.",
            Items = SeedRows.For(ClinicSeed.Items, "Documents"),
            Kind = "documents",
            Actions =
            [
                new ClinicNav("Visit", vm.OpenVisitDetailCommand, true, "icon_clinic")
            ]
        });
    }
}
