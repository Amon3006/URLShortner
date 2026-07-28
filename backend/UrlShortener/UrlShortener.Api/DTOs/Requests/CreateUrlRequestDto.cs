using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Api.DTOs.Requests
{
    public class CreateUrlRequestDto
    {
        [Required]
        [Url]
        [MaxLength(2048)]
        public string OriginalUrl { get; set; } = string.Empty;
    }
}
