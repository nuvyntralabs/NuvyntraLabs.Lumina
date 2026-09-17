using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class RequestDetailPage : ContentPage
{
    public RequestDetailPage(RequestDetailViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Request detail";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = CivicUi.Detail(new CivicModel
        {
            Title = "Request detail",
            Subtitle = "Missed food-waste bin.",
            Items = SeedRows.For(CivicSeed.Items, "RequestDetail"),
            Actions = [
            new CivicNav("Services", vm.OpenServicesCommand, true),
            new CivicNav("Offices", vm.OpenOfficesCommand, false)
        ]
        });
    }
}
