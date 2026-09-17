using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class NfcScanPage : ContentPage
{
    public NfcScanPage(NfcScanViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Scan asset";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Scan(new FieldModel
        {
            Title = "Scan asset",
            Subtitle = "Hold the puck to the asset plate.",
            Items = SeedRows.For(FieldSeed.Items, "NfcScan"),
            Actions = [
            new FieldNav("Assets", vm.OpenAssetsCommand, true),
            new FieldNav("Open asset", vm.OpenAssetDetailCommand, false)
        ]
        });
    }
}
