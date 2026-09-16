using NuvyntraLabs.Lumina.Core;
using NuvyntraLabs.UIKit;

namespace NuvyntraLabs.Lumina.Field;

public sealed class TeamPage : LuminaPage
{
    public TeamPage(TeamViewModel vm) : base("Team", "Harbor Field", "Crew 4 thread.")
    {
        ArgumentNullException.ThrowIfNull(vm);
        BindingContext = vm;
        var rows = FieldSeed.Items.Where(x => x.Group == "Team").ToList();
        if (rows.Count == 0)
        {
            rows = FieldSeed.Items.Take(3).ToList();
        }

        foreach (var row in rows)
        {
            AddCard(row.Title, row.Subtitle);
        }

        Root.Add(new NVChat
        {
            Messages = rows.Select(r => new NVChatMessage { Author = r.Title, Text = r.Subtitle }).ToList()
        });

        
AddAction("JobDetail", vm.OpenJobDetailCommand, NVButtonVariant.Filled);
    }
}
