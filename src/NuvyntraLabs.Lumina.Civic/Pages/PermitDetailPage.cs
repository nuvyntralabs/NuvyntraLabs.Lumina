using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class PermitDetailPage : LuminaPage
{
    public PermitDetailPage(PermitDetailViewModel vm) : base("PermitDetail", "Civic Pulse", "Visitor bay — 3 days.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "PermitDetail").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Permits", vm.OpenPermitsCommand, NVButtonVariant.Filled);        AddAction("Wallet", vm.OpenWalletCommand, NVButtonVariant.Outline);
    }
}
