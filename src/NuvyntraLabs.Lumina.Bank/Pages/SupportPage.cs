using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class SupportPage : ContentPage
{
    public SupportPage(SupportViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Support";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Inbox(new BankModel
        {
            Title = "Support",
            Subtitle = "Secure inbox · typically under 2 min.",
            Items = SeedRows.For(BankSeed.Items, "Support"),
            Kind = "support",
            Actions =
            [
                new BankNav("About the travel card", vm.OpenCardDetailCommand, true, "icon_card")
            ]
        });
    }
}
