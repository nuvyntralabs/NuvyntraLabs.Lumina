using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class PermitsPage : ContentPage
{
    public PermitsPage(PermitsViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Permits";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.List(new CivicModel
        {
            Title = "Permits",
            Subtitle = "Paper the borough issued.",
            Items = SeedRows.For(CivicSeed.Items, "Permits"),
            Kind = "permits",
            Actions = [
            new CivicNav("Permit", vm.OpenPermitDetailCommand, true),
            new CivicNav("Services", vm.OpenServicesCommand, false)
        ]
        });
    }
}
