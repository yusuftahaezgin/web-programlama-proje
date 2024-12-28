using System.Text.Json;
using BerberOtomasyonu.Entity;
using BerberOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace YourProjectNamespace.Controllers
{
    public class RandevuController : Controller
    {
       private readonly Veriler _veri;
        public RandevuController(Veriler veri)
        {
            _veri=veri;
        }

        [HttpGet]
        [Authorize(Roles ="user")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Hizmetler = await _veri.Hizmetler
            .Select(h => new { h.HizmetID, h.HizmetAdi, h.Fiyat })
            .ToListAsync();

            ViewBag.Berberler = new SelectList(await _veri.Berberler.ToListAsync(), "BerberID", "AdSoyad");

            ViewBag.Saatler = Enumerable.Range(9, 9)  // 9 - 17
            .Select(i => new { Saat = $"{i:00}:00" })
            .ToList();
            
            return View();
        }

        [HttpPost]
         [Authorize(Roles ="user")]
        public async Task<IActionResult> Create(Randevu model)
        {
            var musteriID= User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (!ModelState.IsValid)
            {
                ViewBag.Hizmetler = await _veri.Hizmetler
                    .Select(h => new { h.HizmetID, h.HizmetAdi, h.Fiyat })
                    .ToListAsync();
                ViewBag.Berberler = new SelectList(await _veri.Berberler.ToListAsync(), "BerberID", "AdSoyad");

                ViewBag.Saatler = Enumerable.Range(9, 9)
                .Select(i => new { Saat = $"{i:00}:00" })
                .ToList();

                return View(model);
            }


            var mevcutRandevular = await _veri.Randevular
            .Where(r => r.BerberID == model.BerberID 
                    && r.RandevuTarihi.Date == model.RandevuTarihi.Date
                    && r.RandevuSaati == model.RandevuSaati)
            .ToListAsync();

            if (mevcutRandevular.Any())
            {
                ModelState.AddModelError("RandevuSaati", "Bu saatte başka bir randevu mevcut.");
                ViewBag.Hizmetler = await _veri.Hizmetler
                    .Select(h => new { h.HizmetID, h.HizmetAdi, h.Fiyat })
                    .ToListAsync();
                ViewBag.Berberler = new SelectList(await _veri.Berberler.ToListAsync(), "BerberID", "AdSoyad");
                ViewBag.Saatler = Enumerable.Range(9, 9)
                    .Select(i => new { Saat = $"{i:00}:00" })
                    .ToList();

                return View(model);
            }

            model.Durum = false;
            model.MusteriID=int.Parse(musteriID);
            _veri.Randevular.Add(model);
            await _veri.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

         [Authorize(Roles ="user")]
       public async Task<IActionResult> RandevuDetay()
        {
            var musteriID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(musteriID))
            {
                return RedirectToAction("Login", "HesapIslemleri"); 
            }

            var randevular = await _veri.Randevular
                .Where(r => r.MusteriID == int.Parse(musteriID))
                .Include(r => r.Berber)  
                .Include(r => r.Hizmet) 
                .ToListAsync();

            if (!randevular.Any())
            {
                
                TempData["msj"] = "Henüz bir randevunuz bulunmamaktadır.";
                return RedirectToAction("Create", "Randevu");
            }

           
            var randevuDetaylar = randevular.Select(r => new RandevuDetay
            {
                RandevuID = r.RandevuID,
                HizmetAdi = r.Hizmet?.HizmetAdi ?? "Hizmet bulunamadı",
                BerberAdi = r.Berber?.AdSoyad ?? "Berber bulunamadı",
                RandevuTarihi = r.RandevuTarihi,
                RandevuSaati = r.RandevuSaati.ToString(@"hh\:mm"),
                Durum = r.Durum
            }).ToList();

            return View(randevuDetaylar);
        }


    }
}