using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class ConversationPage : LuminaPage
{
    public ConversationPage(ConversationViewModel vm) : base("Conversation", "Nuvexa Clinic", "Thread with Dr. Iyer.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Conversation").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        Root.Add(new NVChat
        {
            Messages = rows.Select(r => new NVChatMessage { Author = r.Title, Text = r.Subtitle }).ToList()
        });

        
AddAction("Inbox", vm.OpenInboxCommand, NVButtonVariant.Filled);        AddAction("InCall", vm.OpenInCallCommand, NVButtonVariant.Outline);
    }
}
