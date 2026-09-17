using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class HelpPage : ContentPage
{
    public HelpPage(HelpViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Help";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "Help",
            Subtitle = "How to use Pulse.",
            Items = SeedRows.For(CivicSeed.Items, "Help"),
            Kind = "help",
            Actions =
            [
                new CivicNav("Faq", vm.OpenFaqCommand, true, "icon_help"),
                new CivicNav("Contact", vm.OpenContactCommand, false, "icon_people", "Write the desk")
            ]
        });
    }
}
