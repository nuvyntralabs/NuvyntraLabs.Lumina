using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class RewardsPage : ContentPage
{
    public RewardsPage(RewardsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Rewards";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "Rewards",
            Subtitle = "Aurora points on debit spend.",
            Items = SeedRows.For(BankSeed.Items, "Rewards"),
            Kind = "rewards",
            Actions =
            [
                new BankNav("Linked cards", vm.OpenCardsCommand, true, "icon_card")
            ]
        });
    }
}
