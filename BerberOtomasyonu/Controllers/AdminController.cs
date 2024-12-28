using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BerberOtomasyonu.Models;
using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BerberOtomasyonu.Controllers;

public class AdminController : Controller
{
    private readonly Veriler _veri;
        public AdminController(Veriler veri)
        {
            _veri=veri;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index() 
        {
            var hizmetler = _veri.Hizmetler.ToList(); 
            var berberler = _veri.Berberler.ToList();

            var viewModel = new AdminIndexView
            {
                Hizmetler = hizmetler,
                Berberler = berberler
            };
            
            return View(viewModel);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult HizmetOlustur()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> HizmetOlustur(Hizmet model){ 
            if(ModelState.IsValid)
            {
                 _veri.Hizmetler.Add(model);
                await _veri.SaveChangesAsync();
                return RedirectToAction("Index","Admin");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> HizmetDuzenle(int? id){
            if(id==null){
                return NotFound();
            }

           var hizmet = await _veri.Hizmetler.FindAsync(id); 
            
            if(hizmet==null){
                return NotFound();
            }

            return View(hizmet);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HizmetDuzenle(int id, Hizmet model){ 
            if(id!=model.HizmetID){ 
                return NotFound();
            }

           if(ModelState.IsValid){
            try
            {
                _veri.Update(model);
                await _veri.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_veri.Hizmetler.Any(o=>o.HizmetID == model.HizmetID)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return RedirectToAction("Index","Admin");
           }
           return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> HizmetSil(int? id){
            if(id==null){
                return NotFound();
            }

           var hizmet = await _veri.Hizmetler.FindAsync(id); 

            if(hizmet==null){
                return NotFound();
            }

            return View(hizmet);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> HizmetSil([FromForm]int id){ 
           var hizmet = await _veri.Hizmetler.FindAsync(id); 
            if(hizmet==null){
                return NotFound();
            }
            _veri.Hizmetler.Remove(hizmet);
            await _veri.SaveChangesAsync();
            return RedirectToAction("Index","Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> BerberEkle()
        {
            ViewBag.Hizmetler=new SelectList(await _veri.Hizmetler.ToListAsync(),"HizmetID","HizmetAdi");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> BerberEkle(Berber model){
            if(ModelState.IsValid)
            {
                _veri.Berberler.Add(model);
                await _veri.SaveChangesAsync();
                return RedirectToAction("Index","Admin");
            }
            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> BerberDuzenle(int? id){
            if(id==null){
                return NotFound();
            }

           var berber = await _veri.Berberler.FindAsync(id); 
            
            if(berber==null){
                return NotFound();
            }
            ViewBag.Hizmetler=new SelectList(await _veri.Hizmetler.ToListAsync(),"HizmetID","HizmetAdi");
            return View(berber);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BerberDuzenle(int id, Berber model){ 
            if(id!=model.BerberID){ 
                return NotFound();
            }

           if(ModelState.IsValid){
            try
            {
                _veri.Update(model);
                await _veri.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_veri.Berberler.Any(o=>o.BerberID == model.BerberID)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return RedirectToAction("Index","Admin");
           }
           ViewBag.Hizmetler=new SelectList(await _veri.Hizmetler.ToListAsync(),"HizmetID","HizmetAdi");
           return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> BerberSil(int? id){
            if(id==null){
                return NotFound();
            }

           var berber = await _veri.Berberler.FindAsync(id); 

            if(berber==null){
                return NotFound();
            }

            return View(berber);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> BerberSil([FromForm]int id){ 
           var berber = await _veri.Berberler.FindAsync(id); 
            if(berber==null){
                return NotFound();
            }
            _veri.Berberler.Remove(berber);
            await _veri.SaveChangesAsync();
            return RedirectToAction("Index","Admin");
        }


        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RandevuListesi() 
        {
            var randevular = await _veri.Randevular
            .Include(r => r.Berber) 
            .Include(r => r.Hizmet)  
            .Include(r => r.Musteri)
            .ToListAsync();

            return View(randevular);
        }

        public async Task<IActionResult> Onayla(int randevuID)
        {
            // Randevu bilgilerini al
            var randevu = await _veri.Randevular
                .FirstOrDefaultAsync(r => r.RandevuID == randevuID);

            if (randevu == null)
            {
                TempData["msj"] = "Randevu bulunamadı.";
                return RedirectToAction("Index");
            }

            // Randevuyu onayla
            randevu.Durum = true;

            await _veri.SaveChangesAsync();

            TempData["msj"] = "Randevu onaylandı.";
            return RedirectToAction("RandevuListesi");
        }


        public IActionResult BerberKazanclar()
        {
            var kazancRaporu = _veri.Randevular
                .Where(r => r.Durum) // Sadece onaylanmış randevular
                .GroupBy(r => r.BerberID) // ÇalışanID'ye göre gruplama
                .Select(grup => new BerberKazanc
                {
                    BerberID = grup.Key,
                    AdSoyad = _veri.Berberler.FirstOrDefault(c => c.BerberID == grup.Key).AdSoyad,
                    ToplamKazanc = grup.Sum(r => _veri.Hizmetler.FirstOrDefault(i => i.HizmetID == r.HizmetID).Fiyat)
                })
                .ToList();

            return View(kazancRaporu);
        }
}