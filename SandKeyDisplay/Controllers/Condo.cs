using Display.Core.Services.Bridge.Stellar.Enums;
using Microsoft.AspNetCore.Mvc;

namespace SandKeyDisplay.Controllers;

public class CondoController : Controller
{
    [Route("Condo/{condoId:int=0}")]
    public IActionResult Index(int condoId)
    {
        var value = CondoConverter.CondoNameById.TryGetValue(condoId, out var condoName) ? $"{condoName}" : string.Empty;
        value = value.Replace("%20", " ");
        ViewBag.CondoName = value;
        ViewBag.CondoId = condoId;
        return View();
    }
    
    public IActionResult Info(string condoName)
    {
        ViewBag.CondoName = condoName;
        return View();
    }
}