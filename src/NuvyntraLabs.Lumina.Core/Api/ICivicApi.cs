using Plugin.Maui.HttpForge;

namespace NuvyntraLabs.Lumina.Core;

public interface ICivicApi
{
    [Get("/civic/items")]
    Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default);

    [Get("/civic/items/{id}")]
    Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default);
}
