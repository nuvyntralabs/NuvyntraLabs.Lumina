using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class VisitDetailPage : ContentPage
{
    public VisitDetailPage(VisitDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Visit";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Detail(new ClinicModel
        {
            Title = "Visit",
            Subtitle = "Follow-up after lipid panel.",
            Items = SeedRows.For(ClinicSeed.Items, "VisitDetail"),
            Kind = "visit",
            Actions =
            [
                new ClinicNav("Prescriptions", vm.OpenPrescriptionsCommand, true, "icon_pill"),
                new ClinicNav("Documents", vm.OpenDocumentsCommand, false, "icon_doc"),
                new ClinicNav("Invoice", vm.OpenInvoiceCommand, false, "icon_doc")
            ]
        });
    }
}
