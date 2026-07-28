using UrlShortener.Api.Models;

namespace UrlShortener.Api.Repository
{
    public interface IUrlRepository
    {
        Task<List<Url>> GetAllAsync();

        Task<Url?> GetByIdAsync(string id);

        Task<Url?> GetByShortCodeAsync(string shortCode);

        Task CreateAsync(Url url);

        Task UpdateAsync(Url url);

        Task DeleteAsync(string id);

        Task<bool> ShortCodeExistsAsync(string shortCode);
    }
}
