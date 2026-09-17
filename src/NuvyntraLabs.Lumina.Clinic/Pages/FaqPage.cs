using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class FaqPage : ContentPage
{
    public FaqPage(FaqViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "FAQ";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.List(new ClinicModel
        {
            Title = "FAQ",
            Subtitle = "Clinic questions.",
            Items = SeedRows.For(ClinicSeed.Items, "Faq"),
            Kind = "faq",
            Actions =
            [
                new ClinicNav("Help", vm.OpenHelpCommand, true, "icon_help")
            ]
        });
    }
}
