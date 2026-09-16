using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InboxPage : LuminaPage
{
    public InboxPage(InboxViewModel vm) : base("Inbox", "Nuvexa Clinic", "Care threads.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Inbox").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Conversation", vm.OpenConversationCommand, NVButtonVariant.Filled);        AddAction("InCall", vm.OpenInCallCommand, NVButtonVariant.Outline);
    }
}
