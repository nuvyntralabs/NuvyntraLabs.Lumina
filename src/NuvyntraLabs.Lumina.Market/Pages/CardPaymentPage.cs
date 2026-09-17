using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class CardPaymentPage : ContentPage
{
    public CardPaymentPage(CardPaymentViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Card payment";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Form(new MarketModel
        {
            Title = "Card payment",
            Subtitle = "Masked PAN on warm paper.",
            Items = SeedRows.For(MarketSeed.Items, "CardPayment"),
            Actions = [
            new MarketNav("Done", vm.OpenPaymentResultCommand, true),
            new MarketNav("Use a saved card", vm.OpenSavedCardsCommand, false)
        ]
        });
    }
}
