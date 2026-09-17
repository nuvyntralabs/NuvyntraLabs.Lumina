using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class AppLockPage : ContentPage
{
    public AppLockPage(AppLockViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "App lock";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Form(new BankModel
        {
            Title = "App lock",
            Subtitle = "Timer, Face ID, and screenshot guard.",
            Items = SeedRows.For(BankSeed.Items, "AppLock"),
            Kind = "lock",
            Actions =
            [
                new BankNav("Test PIN gate", vm.OpenPinLockCommand, true, "icon_shield"),
                new BankNav("Back to you", vm.OpenSettingsCommand, false, "icon_more")
            ]
        });
    }
}
