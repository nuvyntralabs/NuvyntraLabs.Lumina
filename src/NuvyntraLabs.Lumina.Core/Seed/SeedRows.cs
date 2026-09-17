namespace NuvyntraLabs.Lumina.Core;

public static class SeedRows
{
    public static IReadOnlyList<CatalogItem> For(IReadOnlyList<CatalogItem> items, string group)
    {
        ArgumentNullException.ThrowIfNull(items);
        var rows = items.Where(x => x.Group == group).ToList();
        return rows.Count > 0 ? rows : items.Take(3).ToList();
    }
}
