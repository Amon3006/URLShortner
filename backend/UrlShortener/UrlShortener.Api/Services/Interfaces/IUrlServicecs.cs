using UrlShortener.Api.Models;

namespace UrlShortener.Api.Services.Interfaces
{
    public interface IUrlService
    {
        Task<Url> CreateShortUrlAsync(string originalUrl);

        Task<Url?> GetByShortCodeAsync(string shortCode);

        Task<List<Url>> GetAllUrlsAsync();
        Task<Url?> ResolveShortCodeAsync(string shortCode);
        Task DeleteShortUrlAsync(string id);

        Task IncrementClickCountAsync(string shortCode);
    }
}
