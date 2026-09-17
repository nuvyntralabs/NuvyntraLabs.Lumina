using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Field;

public sealed class AssetDetailPage : ContentPage
{
    public AssetDetailPage(AssetDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Asset detail";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = FieldUi.Job(new FieldModel
        {
            Title = "Asset detail",
            Subtitle = "PUMP-441 — Flygt storm pump.",
            Items = SeedRows.For(FieldSeed.Items, "AssetDetail"),
            Actions = [
            new FieldNav("Inspection", vm.OpenInspectionCommand, true),
            new FieldNav("Files", vm.OpenFilesCommand, false)
        ]
        });
    }
}
