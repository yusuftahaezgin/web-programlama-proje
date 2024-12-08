using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BerberOtomasyonu.Controllers;

public class MusteriController : Controller
{
    private readonly Veriler _veri;
        public MusteriController(Veriler veri)
        {
            _veri=veri;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Musteri model){ //musteri ekleme
            _veri.Musteriler.Add(model);
            await _veri.SaveChangesAsync();
            return RedirectToAction("Login","HesapIslemleri");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id){
            if(id==null){
                return NotFound();
            }

           var musteri = await _veri.Musteriler.FindAsync(id); //bu fonk ile sadece id ye gore arama yapabiliriz
            
            if(musteri==null){
                return NotFound();
            }

            return View(musteri);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Musteri model){ // ogrenci guncelleme
            if(id!=model.MusteriID){ // route daki id ile modelden gelen id yi karsilastirdik
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
                if(!_veri.Musteriler.Any(o=>o.MusteriID == model.MusteriID)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return RedirectToAction("Index","Home");
           }
           return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id){
            if(id==null){
                return NotFound();
            }

           var musteri = await _veri.Musteriler.FindAsync(id); 

            if(musteri==null){
                return NotFound();
            }

            return View(musteri);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id){ //formdaki id ile karsilastirdik
           var musteri = await _veri.Musteriler.FindAsync(id); 
            if(musteri==null){
                return NotFound();
            }
            _veri.Musteriler.Remove(musteri);
            await _veri.SaveChangesAsync();
            return RedirectToAction("Logout","HesapIslemleri");
        }

}
