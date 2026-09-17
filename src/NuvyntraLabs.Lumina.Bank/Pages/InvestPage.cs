using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class InvestPage : ContentPage
{
    public InvestPage(InvestViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Invest";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "Invest",
            Subtitle = "Wealth sleeves in Aether.",
            Items = SeedRows.For(BankSeed.Items, "Invest"),
            Kind = "invest",
            Actions =
            [
                new BankNav("Open holding", vm.OpenInvestDetailCommand, true, "icon_chart")
            ]
        });
    }
}
