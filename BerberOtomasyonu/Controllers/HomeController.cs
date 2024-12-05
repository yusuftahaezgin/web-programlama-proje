using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BerberOtomasyonu.Models;

namespace BerberOtomasyonu.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
