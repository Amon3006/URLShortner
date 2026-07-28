namespace UrlShortener.Api.Services.Interfaces
{
    public interface IShortCodeGenerator
    {
        Task<string> GenerateAsync();
    }
}
