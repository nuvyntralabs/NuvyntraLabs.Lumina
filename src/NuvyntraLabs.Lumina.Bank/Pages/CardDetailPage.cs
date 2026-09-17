using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class CardDetailPage : ContentPage
{
    public CardDetailPage(CardDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Aurora debit";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Detail(new BankModel
        {
            Title = "Aurora debit",
            Subtitle = "Physical + tokenised  ··4418",
            Items = SeedRows.For(BankSeed.Items, "CardDetail"),
            Kind = "card",
            Actions =
            [
                new BankNav("Back to cards", vm.OpenCardsCommand, true, "icon_card"),
                new BankNav("Lock the app", vm.OpenAppLockCommand, false, "icon_shield")
            ]
        });
    }
}
