using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class WhatsNewPage : ContentPage
{
    public WhatsNewPage(WhatsNewViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Whats new";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "Whats new",
            Subtitle = "1.0 prototype notes.",
            Items = SeedRows.For(CivicSeed.Items, "WhatsNew"),
            Kind = "whatsnew",
            Actions =
            [
                new CivicNav("About", vm.OpenAboutCommand, true, "icon_council")
            ]
        });
    }
}
