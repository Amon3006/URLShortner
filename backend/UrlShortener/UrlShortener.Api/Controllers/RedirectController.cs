using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Controllers
{
    
    [ApiController]
    public class RedirectController : ControllerBase
    {
        private readonly IUrlService _service;

        public RedirectController(IUrlService service)
        {
            _service = service;
        }
        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            var url = await _service.ResolveShortCodeAsync(shortCode);

            return Redirect(url.OriginalUrl);
        }
    }
}
