using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BerberOtomasyonu.Models;
using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
            return View(hizmetler);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult HizmetOlustur()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> HizmetOlustur(Hizmet model){ //musteri ekleme
            _veri.Hizmetler.Add(model);
            await _veri.SaveChangesAsync();
            return RedirectToAction("Index","Admin");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> HizmetDuzenle(int? id){
            if(id==null){
                return NotFound();
            }

           var hizmet = await _veri.Hizmetler.FindAsync(id); //bu fonk ile sadece id ye gore arama yapabiliriz
            
            if(hizmet==null){
                return NotFound();
            }

            return View(hizmet);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HizmetDuzenle(int id, Hizmet model){ // ogrenci guncelleme
            if(id!=model.HizmetID){ // route daki id ile modelden gelen id yi karsilastirdik
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
        public async Task<IActionResult> HizmetSil([FromForm]int id){ //formdaki id ile karsilastirdik
           var hizmet = await _veri.Hizmetler.FindAsync(id); 
            if(hizmet==null){
                return NotFound();
            }
            _veri.Hizmetler.Remove(hizmet);
            await _veri.SaveChangesAsync();
            return RedirectToAction("Index","Admin");
        }
}