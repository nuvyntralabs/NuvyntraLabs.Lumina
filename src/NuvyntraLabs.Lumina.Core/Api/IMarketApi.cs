using Plugin.Maui.HttpForge;

namespace NuvyntraLabs.Lumina.Core;

public interface IMarketApi
{
    [Get("/market/items")]
    Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default);

    [Get("/market/items/{id}")]
    Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default);
}
