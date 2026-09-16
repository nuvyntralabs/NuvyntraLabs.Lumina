namespace NuvyntraLabs.Lumina.Core;

public sealed class MarketApi : IMarketApi
{
    public Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult<IReadOnlyList<CatalogItem>>(MarketSeed.Items);
    }

    public Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var item = MarketSeed.Items.FirstOrDefault(x => x.Id == id)
            ?? MarketSeed.Items[0];
        return Task.FromResult(item);
    }
}
