using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class AssetsPage : ContentPage
{
    public AssetsPage(AssetsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Assets";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Assets(new FieldModel
        {
            Title = "Assets",
            Subtitle = "Yard register.",
            Items = SeedRows.For(FieldSeed.Items, "Assets"),
            Kind = "assets",
            SelectedTab = "Assets",
            Tabs = FieldTheme.Tabs(vm.OpenHomeCommand, vm.OpenJobsCommand, null, vm.OpenOfflineQueueCommand, vm.OpenSettingsCommand),
            Actions =
            [
                new FieldNav("Open asset", vm.OpenAssetDetailCommand, true, "icon_asset"),
                new FieldNav("Scan", vm.OpenNfcScanCommand, false, "icon_nfc")
            ]
        });
    }
}
