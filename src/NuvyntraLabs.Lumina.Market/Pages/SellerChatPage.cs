using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Market;

public sealed class SellerChatPage : LuminaPage
{
    public SellerChatPage(SellerChatViewModel vm) : base("SellerChat", "Lumina Market", "Thread with Harbour Kitchen.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = MarketSeed.Items.Where(x => x.Group == "SellerChat").ToList();
        if (rows.Count == 0)
        {
            rows = MarketSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        Root.Add(new NVChat
        {
            Messages = rows.Select(r => new NVChatMessage { Author = r.Title, Text = r.Subtitle }).ToList()
        });

        
AddAction("OrderDetail", vm.OpenOrderDetailCommand, NVButtonVariant.Filled);
    }
}
