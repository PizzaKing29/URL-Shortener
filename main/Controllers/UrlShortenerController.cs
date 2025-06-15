using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

[Route("/")]
public class UrlShortenerController : Controller
{

    private static ConcurrentDictionary<string, string> urlMappings = new ConcurrentDictionary<string, string>();

    [HttpPost]
    public IActionResult AcceptData([FromBody] ShortUrl shortUrl)
    {
        if (string.IsNullOrEmpty(shortUrl?.OriginalUrl) ||
            !(shortUrl.OriginalUrl.StartsWith("http://") || shortUrl.OriginalUrl.StartsWith("https://")))
        {
            return BadRequest("Invalid URL");
        }

        do
        {
            shortUrl.GenerateUrlString();
        }
        while (urlMappings.ContainsKey(shortUrl.ShortCode));

        urlMappings[shortUrl.ShortCode] = shortUrl.OriginalUrl;

        string newUrl = $"http://localhost:5000/{shortUrl.ShortCode}";
        return Ok(newUrl);
    }

    [HttpGet("{shortCode}")]
    public IActionResult HandleGetRequest(string shortCode)
    {
        if (urlMappings.TryGetValue(shortCode, out var originalUrl))
        {
            return Redirect(originalUrl);
        }
        else
        {
            return NotFound();
        }
    }
}