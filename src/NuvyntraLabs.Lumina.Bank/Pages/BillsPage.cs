using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class BillsPage : ContentPage
{
    public BillsPage(BillsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Bills";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "Bills",
            Subtitle = "Due this month from current.",
            Items = SeedRows.For(BankSeed.Items, "Bills"),
            Kind = "bills",
            Actions =
            [
                new BankNav("Pay this bill", vm.OpenBillDetailCommand, true, "icon_bill"),
                new BankNav("New transfer", vm.OpenTransferCommand, false, "icon_send")
            ]
        });
    }
}
