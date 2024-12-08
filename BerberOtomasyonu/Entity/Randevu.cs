using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
     public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }

        [Required]
        public int MusteriID { get; set; }

        public Musteri Musteri { get; set; } =null!; // bir randevu bir musteriye ait olabilir

        [Required]
        public int BerberID { get; set; }

        public Berber Berber { get; set; }=null!; // bir randevu bir berbere ait olabilir
        
        public ICollection<Hizmet> Hizmetler { get; set; }= new List<Hizmet>();// bir randevuda birden fazla hizmet olabilir

        [Required]
        public DateTime RandevuTarihi { get; set; }

        [Required]
        public bool Durum { get; set; }
    }
}