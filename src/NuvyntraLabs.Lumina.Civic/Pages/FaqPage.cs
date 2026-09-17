using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class FaqPage : ContentPage
{
    public FaqPage(FaqViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Faq";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "Faq",
            Subtitle = "What residents ask.",
            Items = SeedRows.For(CivicSeed.Items, "Faq"),
            Kind = "faq",
            Actions =
            [
                new CivicNav("Help", vm.OpenHelpCommand, true, "icon_help")
            ]
        });
    }
}
