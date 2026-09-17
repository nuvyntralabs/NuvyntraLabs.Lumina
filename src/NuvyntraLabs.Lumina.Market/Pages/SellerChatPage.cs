using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SellerChatPage : ContentPage
{
    public SellerChatPage(SellerChatViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Seller chat";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = MarketUi.Chat(new MarketModel
        {
            Title = "Seller chat",
            Subtitle = "Thread with Harbour Kitchen.",
            Items = SeedRows.For(MarketSeed.Items, "SellerChat"),
            Actions = [
            new MarketNav("View order", vm.OpenOrderDetailCommand, true)
        ]
        });
    }
}
