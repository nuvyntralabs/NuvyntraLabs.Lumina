using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class BeneficiariesPage : ContentPage
{
    public BeneficiariesPage(BeneficiariesViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "International";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.List(new BankModel
        {
            Title = "International",
            Subtitle = "SWIFT beneficiaries.",
            Items = SeedRows.For(BankSeed.Items, "Beneficiaries"),
            Kind = "beneficiaries",
            Actions =
            [
                new BankNav("UK payees", vm.OpenPayeesCommand, true, "icon_people"),
                new BankNav("Send", vm.OpenTransferCommand, false, "icon_send")
            ]
        });
    }
}
