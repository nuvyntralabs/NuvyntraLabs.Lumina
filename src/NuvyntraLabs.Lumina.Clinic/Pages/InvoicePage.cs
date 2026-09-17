using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InvoicePage : ContentPage
{
    public InvoicePage(InvoiceViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Invoice";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "Invoice",
            Subtitle = "Visit 12 Sep.",
            Items = SeedRows.For(ClinicSeed.Items, "Invoice"),
            Kind = "invoice",
            Actions = [
            new ClinicNav("Visit", vm.OpenVisitDetailCommand, true)
        ]
        });
    }
}
