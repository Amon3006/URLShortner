using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.DTOs.Requests;
using UrlShortener.Api.DTOs.Responses;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UrlController : ControllerBase
    {
        private readonly IUrlService _service;
        public UrlController(IUrlService urlService)
        {
            _service = urlService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var urls = await _service.GetAllUrlsAsync();
            
            return Ok(urls);
        }


        [HttpGet("{shortCode}")]
        public async Task<IActionResult> GetByShortCode(string shortCode)
        {
            var url = await _service.GetByShortCodeAsync(shortCode);

            if (url == null)
                return NotFound();

            var response = new UrlResponseDto
            {
                Id = url.Id ?? string.Empty,
                OriginalUrl = url.OriginalUrl,
                ShortCode = url.ShortCode,
                ShortUrl = $"https://urlshortner-1-y3mm.onrender.com/{url.ShortCode}",
                ClickCount = url.ClickCount
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUrlRequestDto request)
        {
            var url = await _service.CreateShortUrlAsync(request.OriginalUrl);

            var response = new UrlResponseDto
            {
                Id = url.Id ?? string.Empty,
                OriginalUrl = url.OriginalUrl,
                ShortCode = url.ShortCode,
                ShortUrl = $"https://urlshortner-1-y3mm.onrender.com/{url.ShortCode}",
                ClickCount = url.ClickCount
            };

            return CreatedAtAction(
                nameof(GetByShortCode),
                new { shortCode = response.ShortCode },
                response);
        }


    }
    }
