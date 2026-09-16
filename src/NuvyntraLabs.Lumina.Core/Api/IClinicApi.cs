using Plugin.Maui.HttpForge;

namespace NuvyntraLabs.Lumina.Core;

public interface IClinicApi
{
    [Get("/clinic/items")]
    Task<IReadOnlyList<CatalogItem>> ListAsync(CancellationToken cancellationToken = default);

    [Get("/clinic/items/{id}")]
    Task<CatalogItem> GetAsync(string id, CancellationToken cancellationToken = default);
}
