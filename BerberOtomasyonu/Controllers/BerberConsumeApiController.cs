using System.Text;
using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace BerberOtomasyonu.Controllers
{
    public class BerberConsumeApiController : Controller
    {
        private readonly Veriler _veri;
        public BerberConsumeApiController(Veriler veri)
        {
            _veri=veri;
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            List<Berber> berberler = new List<Berber>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5081/api/BerberApi/");
            var jsondata = await response.Content.ReadAsStringAsync();
            berberler = JsonConvert.DeserializeObject<List<Berber>>(jsondata);
            return View(berberler);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Ekle()
        {
            ViewBag.Hizmetler=new SelectList(await _veri.Hizmetler.ToListAsync(),"HizmetID","HizmetAdi");
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Ekle(Berber model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var jsonContent = JsonConvert.SerializeObject(model);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5081/api/BerberApi/", content);


                if (response.IsSuccessStatusCode)
                {
                    var successMessage = await response.Content.ReadAsStringAsync();
                    TempData["Success"] = successMessage;
                    return RedirectToAction("Index");
                }

                else
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    TempData["Error"] = $"API Hatası: {response.StatusCode}, Detay: {errorDetails}";
                    return RedirectToAction("Ekle");
                }
            }

            catch (Exception ex)
            {
                TempData["Error"] = $"Beklenmeyen bir hata oluştu: {ex.Message}";
                return RedirectToAction("Ekle");
            }
        }
    }
}