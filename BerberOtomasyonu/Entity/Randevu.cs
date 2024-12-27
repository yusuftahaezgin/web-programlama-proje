using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
     public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }

        [Required]
        public int MusteriID { get; set; }

        [Required]
        public int BerberID { get; set; }

        [Required]
        public int HizmetID { get; set; }
        
        [Required]
        public DateTime RandevuTarihi { get; set; }
        
        [Required]
        public TimeSpan RandevuSaati { get; set; }

        [Required]
        public bool Durum { get; set; }

        public Berber? Berber { get; set; }
        public Hizmet? Hizmet { get; set; }
        public Musteri? Musteri { get; set; }
    }
    }