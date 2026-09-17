using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class AddressesPage : ContentPage
{
    public AddressesPage(AddressesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Addresses";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Form(new MarketModel
        {
            Title = "Addresses",
            Subtitle = "Where crates land.",
            Items = SeedRows.For(MarketSeed.Items, "Addresses"),
            Actions = [
            new MarketNav("Checkout", vm.OpenCheckoutCommand, true)
        ]
        });
    }
}
