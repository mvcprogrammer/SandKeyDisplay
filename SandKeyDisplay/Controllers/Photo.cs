using Display.Core.Services.Bridge.Stellar.HttpClient;
using Microsoft.AspNetCore.Mvc;

namespace SandKeyDisplay.Controllers;

public class Photo : Controller
{
    [Route("Photo/{section1}/{section2}/{photoId}")]
    public async Task<FileContentResult?> Index(string section1, string section2, string photoId)
    {
        var bytes = await PhotoClient.GetAsync($"{section1}/{section2}/{photoId}");
        return bytes == null ? null : File(bytes, "image/jpeg");
    }
}