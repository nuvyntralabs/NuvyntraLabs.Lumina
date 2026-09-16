using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Clinic;

public sealed class WalkthroughPage : LuminaPage
{
    public WalkthroughPage(WalkthroughViewModel vm) : base("Walkthrough", "Nuvexa Clinic", "Care without the clipboard pile.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = ClinicSeed.Items.Where(x => x.Group == "Walkthrough").ToList();
        if (rows.Count == 0)
        {
            rows = ClinicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        Root.Add(new NVCarousel { Items = rows.Select(r => r.Title).ToList() });
        Root.Add(new NVDotIndicator { Count = 3, Index = 0 });

        
AddAction("SignIn", vm.OpenSignInCommand, NVButtonVariant.Filled);
    }
}
