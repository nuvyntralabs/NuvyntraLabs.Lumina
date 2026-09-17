using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class ConversationPage : ContentPage
{
    public ConversationPage(ConversationViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Conversation";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Chat(new ClinicModel
        {
            Title = "Dr. Iyer",
            Subtitle = "Thread with Dr. Iyer.",
            Items = SeedRows.For(ClinicSeed.Items, "Conversation"),
            Kind = "chat",
            Actions = [
            new ClinicNav("Inbox", vm.OpenInboxCommand, true),
            new ClinicNav("Join call", vm.OpenInCallCommand, false)
        ]
        });
    }
}
