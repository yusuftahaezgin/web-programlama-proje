using BerberOtomasyonu.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BerberOtomasyonu.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BerberApiController : ControllerBase
    {
        private readonly Veriler _veri;
        public BerberApiController(Veriler veri)
        {
            _veri=veri;
        }

        [HttpGet]
        public List<Berber> Get()
        {
            var berberler=_veri.Berberler.ToList();

            return berberler;
        }

        [HttpGet("{id}")]
        public ActionResult<Berber> Get(int id)
        {
            var berber =_veri.Berberler.FirstOrDefault(x=>x.BerberID==id);
            if (berber is null)
            {
                return NoContent();
            }
            return berber;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Berber model)
        {
            _veri.Berberler.Add(model);
            _veri.SaveChanges();
            return Ok(model.AdSoyad+" isimli berber eklendi");
        }
    }
}