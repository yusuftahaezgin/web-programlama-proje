using System.Security.Claims;
using BerberOtomasyonu.Entity;
using BerberOtomasyonu.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BerberOtomasyonu.Controllers
{
    public class HesapIslemleriController : Controller
    {

        private readonly Veriler _veri;
        public HesapIslemleriController(Veriler veri)
        {
            _veri=veri;
        }
       
        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var kullanici = await _veri.Musteriler.FirstOrDefaultAsync(x => x.Email == model.Email && x.Sifre == model.Sifre);

                var admin = await _veri.Adminler.FirstOrDefaultAsync(x => x.Email == model.Email && x.Sifre == model.Sifre);

                if(kullanici != null)
                {
                    var kullaniciBilgileri = new List<Claim>();

                    kullaniciBilgileri.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.MusteriID.ToString()));
                    kullaniciBilgileri.Add(new Claim(ClaimTypes.Name, kullanici.KullaniciAdi ?? ""));
                    kullaniciBilgileri.Add(new Claim(ClaimTypes.GivenName, kullanici.AdSoyad ?? ""));

                    kullaniciBilgileri.Add(new Claim(ClaimTypes.Role, "user"));


                    var claimsIdentity = new ClaimsIdentity(kullaniciBilgileri, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties 
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), 
                        authProperties);

                    return RedirectToAction("Index","Home");
                }
                else if(admin != null)
                {
                    var adminBilgileri = new List<Claim>();

                    adminBilgileri.Add(new Claim(ClaimTypes.NameIdentifier, admin.AdminID.ToString()));
                    adminBilgileri.Add(new Claim(ClaimTypes.Name, admin.KullaniciAdi ?? ""));
                    adminBilgileri.Add(new Claim(ClaimTypes.GivenName, admin.AdSoyad ?? ""));

                    adminBilgileri.Add(new Claim(ClaimTypes.Role, "admin"));

                    var claimsIdentity = new ClaimsIdentity(adminBilgileri, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties 
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), 
                        authProperties);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            } 
            
            return View(model);
        }

        
    }
}