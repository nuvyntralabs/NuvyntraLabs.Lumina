namespace NuvyntraLabs.Lumina.Core;

public sealed class CivicApi : ICivicApi
{
    public Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult<IReadOnlyList<CatalogItem>>(CivicSeed.Items);
    }

    public Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var item = CivicSeed.Items.FirstOrDefault(x => x.Id == id)
            ?? CivicSeed.Items[0];
        return Task.FromResult(item);
    }
}
