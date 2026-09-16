namespace NuvyntraLabs.Lumina.Core;

public sealed class BankApi : IBankApi
{
    public Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult<IReadOnlyList<CatalogItem>>(BankSeed.Items);
    }

    public Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var item = BankSeed.Items.FirstOrDefault(x => x.Id == id)
            ?? BankSeed.Items[0];
        return Task.FromResult(item);
    }
}
