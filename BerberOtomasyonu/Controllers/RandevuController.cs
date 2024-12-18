using BerberOtomasyonu.Entity;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Randevu model){ //randevu ekleme
            _veri.Randevular.Add(model);
            await _veri.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
