using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class ReceiptPage : ContentPage
{
    public ReceiptPage(ReceiptViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Receipt";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Receipt",
            Subtitle = "Job ticket HF-204.",
            Items = SeedRows.For(FieldSeed.Items, "Receipt"),
            Kind = "receipt",
            Actions = [
            new FieldNav("Printers", vm.OpenPrintersCommand, true),
            new FieldNav("Job", vm.OpenJobDetailCommand, false)
        ]
        });
    }
}
