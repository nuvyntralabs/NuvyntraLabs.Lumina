using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CheckoutPage : ContentPage
{
    public CheckoutPage(CheckoutViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Checkout";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Form(new MarketModel
        {
            Title = "Checkout",
            Subtitle = "Address plus slot.",
            Items = SeedRows.For(MarketSeed.Items, "Checkout"),
            Actions = [
            new MarketNav("Pay now", vm.OpenCardPaymentCommand, true),
            new MarketNav("Change address", vm.OpenAddressesCommand, false)
        ]
        });
    }
}
