using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class LoanDetailPage : ContentPage
{
    public LoanDetailPage(LoanDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Studio loan";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Detail(new BankModel
        {
            Title = "Studio loan",
            Subtitle = "4.2% APR  ·  ends Apr 2029",
            Items = SeedRows.For(BankSeed.Items, "LoanDetail"),
            Kind = "loan",
            Actions =
            [
                new BankNav("Make a payment", vm.OpenTransferCommand, true, "icon_send"),
                new BankNav("All credit", vm.OpenLoansCommand, false, "icon_loan")
            ]
        });
    }
}
