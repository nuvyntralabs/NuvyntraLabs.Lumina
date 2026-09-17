using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class TicketDetailPage : ContentPage
{
    public TicketDetailPage(TicketDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Ticket detail";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Detail(new CivicModel
        {
            Title = "Ticket detail",
            Subtitle = "Day rover — QR on paper.",
            Items = SeedRows.For(CivicSeed.Items, "TicketDetail"),
            Actions = [
            new CivicNav("Transit", vm.OpenTransitCommand, true),
            new CivicNav("Wallet", vm.OpenWalletCommand, false)
        ]
        });
    }
}
