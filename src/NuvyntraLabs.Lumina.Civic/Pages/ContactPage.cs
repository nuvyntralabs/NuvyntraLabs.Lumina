using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class ContactPage : ContentPage
{
    public ContactPage(ContactViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Contact";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Form(new CivicModel
        {
            Title = "Contact",
            Subtitle = "Write the desk.",
            Items = SeedRows.For(CivicSeed.Items, "Contact"),
            Actions = [
            new CivicNav("Services", vm.OpenServicesCommand, true),
            new CivicNav("Help", vm.OpenHelpCommand, false)
        ]
        });
    }
}
