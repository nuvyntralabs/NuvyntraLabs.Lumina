using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class PinLockPage : ContentPage
{
    public PinLockPage(PinLockViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Enter PIN";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Lock(new BankModel
        {
            Title = "Enter PIN",
            Subtitle = "Six digits to open Aether.",
            Items = SeedRows.For(BankSeed.Items, "PinLock"),
            Actions =
            [
                new BankNav("Continue", vm.OpenDashboardCommand, true, "icon_home")
            ]
        });
    }
}
