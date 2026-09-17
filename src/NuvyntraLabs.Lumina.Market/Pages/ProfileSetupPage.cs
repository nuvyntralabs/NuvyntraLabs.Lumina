using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class ProfileSetupPage : ContentPage
{
    public ProfileSetupPage(ProfileSetupViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Your profile";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Form(new MarketModel
        {
            Title = "Your profile",
            Subtitle = "Avatar, kitchen name, delivery default.",
            Items = SeedRows.For(MarketSeed.Items, "ProfileSetup"),
            Actions = [
            new MarketNav("Continue", vm.OpenHomeCommand, true)
        ]
        });
    }
}
