using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class SignInPage : ContentPage
{
    public SignInPage(SignInViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Welcome back";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = BankUi.Auth(new BankModel
        {
            Title = "Welcome back",
            Subtitle = "Member number, email, or Face ID.",
            Items = SeedRows.For(BankSeed.Items, "SignIn"),
            Actions =
            [
                new BankNav("Sign in", vm.SignInCommand, true, "icon_user"),
                new BankNav("Unlock with PIN", vm.OpenPinLockCommand, false, "icon_shield")
            ]
        });
    }
}
