using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class InCallPage : LuminaPage
{
    public InCallPage(InCallViewModel vm) : base("InCall", "Nuvexa Clinic", "Video room — on hold chrome.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "InCall").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }
        Root.Add(new NVInCallView());

        
AddAction("Conversation", vm.OpenConversationCommand, NVButtonVariant.Filled);
    }
}
