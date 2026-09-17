using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InCallPage : ContentPage
{
    public InCallPage(InCallViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Video consult";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Call(new ClinicModel
        {
            Title = "Video consult",
            Subtitle = "Video room — on hold chrome.",
            Items = SeedRows.For(ClinicSeed.Items, "InCall"),
            Kind = "call",
            Actions = [
            new ClinicNav("Open thread", vm.OpenConversationCommand, true)
        ]
        });
    }
}
