using UrlShortener.Api.Repository;
using UrlShortener.Api.Services.Interfaces;
using System.Security.Cryptography;
namespace UrlShortener.Api.Services
{
    
    public class ShortCodeGenerator : IShortCodeGenerator
    {
        private const string Characters =
    "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789";
        private const int CodeLength = 6;
        private const int MaxAttempts = 10;

        private readonly IUrlRepository _repository;

        public ShortCodeGenerator(IUrlRepository repository)
        {
            _repository = repository;
        }

        private static string GenerateCode()
        {
            Span<char> buffer = stackalloc char[CodeLength];

            for (int i = 0; i < buffer.Length; i++)
            {
                int index = RandomNumberGenerator.GetInt32(Characters.Length);

                buffer[i] = Characters[index];
            }

            return new string(buffer);
        }
        public async Task<string> GenerateAsync()
        {
            for (int attempt = 0; attempt < MaxAttempts; attempt++)
            {
                string code = GenerateCode();

                bool exists =
                    await _repository.ShortCodeExistsAsync(code);

                if (!exists)
                    return code;
            }

            throw new InvalidOperationException(
                "Unable to generate a unique short code.");
        }

        
    }
}
