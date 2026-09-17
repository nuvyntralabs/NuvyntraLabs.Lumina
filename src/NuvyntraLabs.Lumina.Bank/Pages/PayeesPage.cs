using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class PayeesPage : ContentPage
{
    public PayeesPage(PayeesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Payees";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "Payees",
            Subtitle = "Saved UK Faster Payments.",
            Items = SeedRows.For(BankSeed.Items, "Payees"),
            Kind = "payees",
            Actions =
            [
                new BankNav("Send to payee", vm.OpenTransferCommand, true, "icon_send"),
                new BankNav("International", vm.OpenBeneficiariesCommand, false, "icon_globe")
            ]
        });
    }
}
