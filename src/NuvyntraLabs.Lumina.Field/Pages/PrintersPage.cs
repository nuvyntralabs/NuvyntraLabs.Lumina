using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class PrintersPage : ContentPage
{
    public PrintersPage(PrintersViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Printers";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Printers",
            Subtitle = "SPP and BLE receipts.",
            Items = SeedRows.For(FieldSeed.Items, "Printers"),
            Kind = "printers",
            Actions = [
            new FieldNav("Receipt", vm.OpenReceiptCommand, true)
        ]
        });
    }
}
