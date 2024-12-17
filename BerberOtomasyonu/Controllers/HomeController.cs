using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BerberOtomasyonu.Models;
using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Authorization;

namespace BerberOtomasyonu.Controllers;

public class HomeController : Controller
{

    public IActionResult Index() // ana sayfa
    {
        var bilgiler = User.Claims;
        return View();
    }

    [Authorize(Roles = "admin")]
    public IActionResult AdminPanel() // sadece adminin erisecegi panel 
    {
        return View();
    }

    [Authorize(Roles = "user")]
    public IActionResult UserPanel() // sadece user erisecegi panel 
    {
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
