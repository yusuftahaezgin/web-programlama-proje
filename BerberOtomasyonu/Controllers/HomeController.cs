using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace BerberOtomasyonu.Controllers;

public class HomeController : Controller
{

    public IActionResult Index() // ana sayfa
    {
        var bilgiler = User.Claims;
        return View();
    }

    public IActionResult Hizmetler() 
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult ErisimHatasi(string? returnUrl)
    {
        return RedirectToAction("Index","Home");
    }

    

}
