using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Civic;

public sealed class RequestDetailPage : LuminaPage
{
    public RequestDetailPage(RequestDetailViewModel vm) : base("RequestDetail", "Civic Pulse", "Missed food-waste bin.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = CivicSeed.Items.Where(x => x.Group == "RequestDetail").ToList();
        if (rows.Count == 0)
        {
            rows = CivicSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        
AddAction("Services", vm.OpenServicesCommand, NVButtonVariant.Filled);        AddAction("Offices", vm.OpenOfficesCommand, NVButtonVariant.Outline);
    }
}
