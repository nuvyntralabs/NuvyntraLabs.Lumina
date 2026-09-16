using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Bank;

public sealed class SupportPage : LuminaPage
{
    public SupportPage(SupportViewModel vm) : base("Support", "Aether Bank", "Secure inbox.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = BankSeed.Items.Where(x => x.Group == "Support").ToList();
        if (rows.Count == 0)
        {
            rows = BankSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        Root.Add(new NVChat
        {
            Messages = rows.Select(r => new NVChatMessage { Author = r.Title, Text = r.Subtitle }).ToList()
        });

        
AddAction("CardDetail", vm.OpenCardDetailCommand, NVButtonVariant.Filled);
    }
}
