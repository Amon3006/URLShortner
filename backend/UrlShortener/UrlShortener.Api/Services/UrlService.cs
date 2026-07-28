using UrlShortener.Api.Exceptions;
using UrlShortener.Api.Models;
using UrlShortener.Api.Repository;
using UrlShortener.Api.Services.Interfaces;
namespace UrlShortener.Api.Services
{
    public class UrlService: IUrlService
    {
        private readonly IUrlRepository _repository;

        private readonly IShortCodeGenerator _generator;
        public UrlService(IUrlRepository repository, IShortCodeGenerator generator)
        {
            _repository = repository;
            _generator = generator;
        }

        public async Task<Url> CreateShortUrlAsync(string originalUrl)
        {
            string shortCode =
    await _generator.GenerateAsync();
            var url = new Url
            {
                OriginalUrl = originalUrl,
                ShortCode = shortCode,
                ClickCount = 0,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = null
            };

            await _repository.CreateAsync(url);

            return url;
        }
        public async Task<List<Url>> GetAllUrlsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Url?> GetByShortCodeAsync(string shortCode)
        {
            return await _repository.GetByShortCodeAsync(shortCode);
        }

        public async Task DeleteShortUrlAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task IncrementClickCountAsync(string shortCode)
        {
            var url = await _repository.GetByShortCodeAsync(shortCode);

            if (url == null)
                return;

            url.ClickCount++;

            await _repository.UpdateAsync(url);
        }

        public async Task<Url?> ResolveShortCodeAsync(string shortCode)
        {
            var url = await _repository.GetByShortCodeAsync(shortCode);

            if (url == null)
               throw new NotFoundException("Short code not found.");

            // Expiry check (we'll expand this shortly)
            if (url.ExpiresAt.HasValue &&
                url.ExpiresAt.Value <= DateTime.UtcNow)
            {
                return null;
            }

            url.ClickCount++;

            await _repository.UpdateAsync(url);

            return url;
        }
    }
}
