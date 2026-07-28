namespace UrlShortener.Api.DTOs.Responses
{
    public class UrlResponseDto
    {

        public string Id { get; set; } = string.Empty;

        public string OriginalUrl { get; set; } = string.Empty;

        public string ShortCode { get; set; } = string.Empty;

        public string ShortUrl { get; set; } = string.Empty;

        public int ClickCount { get; set; }
    }
}
