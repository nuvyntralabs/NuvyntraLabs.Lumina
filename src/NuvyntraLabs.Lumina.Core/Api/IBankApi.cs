using Plugin.Maui.HttpForge;

namespace NuvyntraLabs.Lumina.Core;

public interface IBankApi
{
    [Get("/bank/items")]
    Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default);

    [Get("/bank/items/{id}")]
    Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default);
}
