using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class CardsPage : ContentPage
{
    public CardsPage(CardsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Cards";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Cards(new BankModel
        {
            Title = "Cards",
            Subtitle = "Debit and metal in your wallet.",
            Items = SeedRows.For(BankSeed.Items, "Cards"),
            Kind = "cards",
            SelectedTab = "Cards",
            Tabs = BankTheme.Tabs(vm.OpenHomeCommand, vm.OpenAccountsCommand, vm.OpenPayCommand, null, vm.OpenMoreCommand),
            Actions =
            [
                new BankNav("Card", vm.OpenCardDetailCommand, true, "icon_card")
            ]
        });
    }
}
