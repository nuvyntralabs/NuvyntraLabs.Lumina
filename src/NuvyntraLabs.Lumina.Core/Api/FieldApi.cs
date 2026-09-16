namespace NuvyntraLabs.Lumina.Core;

public sealed class FieldApi : IFieldApi
{
    public Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult<IReadOnlyList<CatalogItem>>(FieldSeed.Items);
    }

    public Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var item = FieldSeed.Items.FirstOrDefault(x => x.Id == id)
            ?? FieldSeed.Items[0];
        return Task.FromResult(item);
    }
}
