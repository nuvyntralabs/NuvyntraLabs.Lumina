using Plugin.Maui.LocalStore;

namespace NuvyntraLabs.Lumina.Core;

public static class LuminaStore
{
    public static async Task SeedAsync(ILocalStore store, string collection, IReadOnlyList<CatalogItem> items, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(store);
        var col = store.GetCollection<CatalogItem>(collection);
        var existing = await col.FindAsync().ConfigureAwait(false);
        if (existing.Count > 0)
        {
            return;
        }

        await col.InsertManyAsync(items.ToList()).ConfigureAwait(false);
    }
}
