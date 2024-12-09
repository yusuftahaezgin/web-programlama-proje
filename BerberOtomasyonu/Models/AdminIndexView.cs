using System.ComponentModel.DataAnnotations;
using BerberOtomasyonu.Entity;

namespace BerberOtomasyonu.Models
{
    public class AdminIndexView
    {
        // Hizmetlerin listesi
        public IEnumerable<Hizmet> Hizmetler { get; set; } = new List<Hizmet>();

        // Berberlerin listesi
        public IEnumerable<Berber> Berberler { get; set; } = new List<Berber>();
    }
}