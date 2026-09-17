using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class PermitDetailPage : ContentPage
{
    public PermitDetailPage(PermitDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Permit detail";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Detail(new CivicModel
        {
            Title = "Permit detail",
            Subtitle = "Visitor bay — 3 days.",
            Items = SeedRows.For(CivicSeed.Items, "PermitDetail"),
            Actions = [
            new CivicNav("Permits", vm.OpenPermitsCommand, true),
            new CivicNav("Wallet", vm.OpenWalletCommand, false)
        ]
        });
    }
}
