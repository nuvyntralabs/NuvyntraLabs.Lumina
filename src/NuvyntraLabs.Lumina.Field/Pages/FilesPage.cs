using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class FilesPage : ContentPage
{
    public FilesPage(FilesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Files";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.List(new FieldModel
        {
            Title = "Files",
            Subtitle = "Drawings on the device.",
            Items = SeedRows.For(FieldSeed.Items, "Files"),
            Kind = "files",
            Actions = [
            new FieldNav("Open asset", vm.OpenAssetDetailCommand, true)
        ]
        });
    }
}
