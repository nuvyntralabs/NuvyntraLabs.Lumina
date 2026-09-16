using Plugin.Maui.HttpForge;

namespace NuvyntraLabs.Lumina.Core;

public interface IFieldApi
{
    [Get("/field/items")]
    Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default);

    [Get("/field/items/{id}")]
    Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default);
}
