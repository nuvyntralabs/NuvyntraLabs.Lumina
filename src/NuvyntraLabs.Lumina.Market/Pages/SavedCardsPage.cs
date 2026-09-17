using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SavedCardsPage : ContentPage
{
    public SavedCardsPage(SavedCardsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Saved cards";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Form(new MarketModel
        {
            Title = "Saved cards",
            Subtitle = "Instruments on file.",
            Items = SeedRows.For(MarketSeed.Items, "SavedCards"),
            Actions = [
            new MarketNav("Pay now", vm.OpenCardPaymentCommand, true)
        ]
        });
    }
}
