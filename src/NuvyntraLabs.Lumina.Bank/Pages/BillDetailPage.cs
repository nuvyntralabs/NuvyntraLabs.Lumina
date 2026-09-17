using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class BillDetailPage : ContentPage
{
    public BillDetailPage(BillDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Council tax";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Detail(new BankModel
        {
            Title = "Council tax",
            Subtitle = "Harbour borough  ·  September",
            Items = SeedRows.For(BankSeed.Items, "BillDetail"),
            Kind = "bill",
            Actions =
            [
                new BankNav("Pay now", vm.OpenTransferCommand, true, "icon_send"),
                new BankNav("All bills", vm.OpenBillsCommand, false, "icon_bill")
            ]
        });
    }
}
