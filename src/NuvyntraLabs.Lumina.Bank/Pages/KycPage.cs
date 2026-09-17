using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class KycPage : ContentPage
{
    public KycPage(KycViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Verify";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Form(new BankModel
        {
            Title = "Verify",
            Subtitle = "Refresh your file so we can keep Premier.",
            Items = SeedRows.For(BankSeed.Items, "Kyc"),
            Kind = "kyc",
            Actions =
            [
                new BankNav("Save and return", vm.OpenSettingsCommand, true, "icon_kyc")
            ]
        });
    }
}
