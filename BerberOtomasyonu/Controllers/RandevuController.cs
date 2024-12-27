using System.Text.Json;
using BerberOtomasyonu.Entity;
using BerberOtomasyonu.Models;
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
        public async Task<IActionResult> Create()
        {
            ViewBag.Hizmetler = await _veri.Hizmetler
            .Select(h => new { h.HizmetID, h.HizmetAdi, h.Fiyat })
            .ToListAsync();


            ViewBag.Berberler = new SelectList(await _veri.Berberler.ToListAsync(), "BerberID", "AdSoyad");

            ViewBag.Saatler = Enumerable.Range(9, 9) // 9'dan başla ve 9 saat ekle (09:00 - 17:00)
            .Select(i => new { Saat = $"{i:00}:00" })
            .ToList();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Randevu model)
        {
           
            var musteriID= User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (!ModelState.IsValid)
            {
                // Eğer hata varsa, formu tekrar doldurması için kullanıcıya geri dön
                ViewBag.Hizmetler = await _veri.Hizmetler
                    .Select(h => new { h.HizmetID, h.HizmetAdi, h.Fiyat })
                    .ToListAsync();
                ViewBag.Berberler = new SelectList(await _veri.Berberler.ToListAsync(), "BerberID", "AdSoyad");

                ViewBag.Saatler = Enumerable.Range(9, 9)
                .Select(i => new { Saat = $"{i:00}:00" })
                .ToList();

                return View(model);
            }

            // Randevu saati çakışmasını kontrol et
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

            model.Durum = false; // Başlangıçta onay bekleyen randevu
            model.MusteriID=int.Parse(musteriID);
            _veri.Randevular.Add(model);
            await _veri.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

         // Randevu Detaylarını Görüntüleme
       public async Task<IActionResult> RandevuDetay()
        {
            var musteriID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(musteriID))
            {
                return RedirectToAction("Login", "HesapIslemleri"); // Giriş yapmamışsa login ol
            }

            // Kullanıcıya ait randevuyu çekiyoruz ve ilişkili Berber ve Hizmet verilerini dahil ediyoruz
            var randevu = await _veri.Randevular
                .Where(r => r.MusteriID == int.Parse(musteriID))
                .Include(r => r.Berber)  // Berber ilişkisini dahil et
                .Include(r => r.Hizmet)  // Hizmet ilişkisini dahil et
                .FirstOrDefaultAsync();

            if (randevu == null)
            {
                // Eğer randevu bulunamazsa, uygun bir mesaj gösterilebilir
                TempData["msj"] = "Henüz bir randevunuz bulunmamaktadır.";
                return RedirectToAction("Create", "Randevu");
            }

            var randevuDetay = new RandevuDetay
            {
                RandevuID = randevu.RandevuID,
                HizmetAdi = randevu.Hizmet?.HizmetAdi ?? "Hizmet bulunamadı",
                BerberAdi = randevu.Berber?.AdSoyad ?? "Berber bulunamadı",
                RandevuTarihi = randevu.RandevuTarihi,
                RandevuSaati = randevu.RandevuSaati.ToString(@"hh\:mm"),
                Durum = randevu.Durum
            };

            return View(randevuDetay); // DTO'yu view'a gönderiyoruz
        }


    }
}