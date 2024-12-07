using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BerberOtomasyonu.Models;
using BerberOtomasyonu.Entity;

namespace BerberOtomasyonu.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        var bilgiler = User.Claims;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
  

}
