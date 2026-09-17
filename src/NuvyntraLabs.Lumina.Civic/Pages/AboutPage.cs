using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class AboutPage : ContentPage
{
    public AboutPage(AboutViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "About";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "About",
            Subtitle = "Civic Pulse · Lumina prototype.",
            Items = SeedRows.For(CivicSeed.Items, "About"),
            Kind = "about",
            Actions =
            [
                new CivicNav("You", vm.OpenSettingsCommand, true, "icon_user")
            ]
        });
    }
}
