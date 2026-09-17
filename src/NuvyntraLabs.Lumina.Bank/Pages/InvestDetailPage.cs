using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class InvestDetailPage : ContentPage
{
    public InvestDetailPage(InvestDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Aurora 80";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Detail(new BankModel
        {
            Title = "Aurora 80",
            Subtitle = "Global equity tilt  ·  accumulating",
            Items = SeedRows.For(BankSeed.Items, "InvestDetail"),
            Kind = "invest",
            Actions =
            [
                new BankNav("All holdings", vm.OpenInvestCommand, true, "icon_chart"),
                new BankNav("Statements", vm.OpenStatementsCommand, false, "icon_statement")
            ]
        });
    }
}
