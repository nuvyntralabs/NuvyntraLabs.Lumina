namespace NuvyntraLabs.Lumina.Core;

public sealed class ClinicApi : IClinicApi
{
    public Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult<IReadOnlyList<CatalogItem>>(ClinicSeed.Items);
    }

    public Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var item = ClinicSeed.Items.FirstOrDefault(x => x.Id == id)
            ?? ClinicSeed.Items[0];
        return Task.FromResult(item);
    }
}
