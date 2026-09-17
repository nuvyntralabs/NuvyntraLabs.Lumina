using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class LoansPage : ContentPage
{
    public LoansPage(LoansViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Credit";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "Credit",
            Subtitle = "Loans and unused overdraft.",
            Items = SeedRows.For(BankSeed.Items, "Loans"),
            Kind = "loans",
            Actions =
            [
                new BankNav("Open facility", vm.OpenLoanDetailCommand, true, "icon_loan")
            ]
        });
    }
}
