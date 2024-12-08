using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BerberOtomasyonu.Models;
using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Authorization;

namespace BerberOtomasyonu.Controllers;

public class AdminController : Controller
{
    private readonly Veriler _veri;
        public AdminController(Veriler veri)
        {
            _veri=veri;
        }
        
}