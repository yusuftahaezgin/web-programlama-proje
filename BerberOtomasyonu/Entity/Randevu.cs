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

        public Berber Berber { get; set; }=null!;// bir randevu bir berbere ait olabilir
        public int HizmetID { get; set; }
        public Hizmet Hizmet { get; set; }=null!;
        
        [Required]
        public DateTime RandevuTarihi { get; set; }

        [Required]
        public bool Durum { get; set; }
    }
}