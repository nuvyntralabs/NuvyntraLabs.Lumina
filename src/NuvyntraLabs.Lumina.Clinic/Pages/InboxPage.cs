using NuvyntraLabs.Lumina.Core;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InboxPage : ContentPage
{
    public InboxPage(InboxViewModel vm)
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        Title = "Messages";
        NavigationPage.SetHasNavigationBar(this, false);
        Content = ClinicUi.Inbox(new ClinicModel
        {
            Title = "Messages",
            Subtitle = "Care threads.",
            Items = SeedRows.For(ClinicSeed.Items, "Inbox"),
            Kind = "inbox",
            Actions =
            [
                new ClinicNav("Open thread", vm.OpenConversationCommand, true, "icon_chat"),
                new ClinicNav("Join call", vm.OpenInCallCommand, false, "icon_video")
            ]
        });
    }
}
