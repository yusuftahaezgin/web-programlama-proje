using System.Security.Claims;
using BerberOtomasyonu.Entity;
using BerberOtomasyonu.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


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
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)  
            {
                var kullanici = _veri.Musteriler.FirstOrDefault(x => x.Email == model.Email && x.Sifre == model.Sifre);

                if(kullanici != null)
                {
                    var kullaniciBilgileri = new List<Claim>();

                    kullaniciBilgileri.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.MusteriID.ToString()));
                    kullaniciBilgileri.Add(new Claim(ClaimTypes.Name, kullanici.KullaniciAdi ?? ""));
                    kullaniciBilgileri.Add(new Claim(ClaimTypes.GivenName, kullanici.AdSoyad ?? ""));

                    if(kullanici.Email == "g221210008@sakarya.edu.tr")
                    {
                        kullaniciBilgileri.Add(new Claim(ClaimTypes.Role, "admin"));
                    } 

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
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            } 
            
            return View(model);
        }

        
    }
}