using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
    public class Berber
    {
        [Key]
        public int BerberID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? AdSoyad { get; set; }

        [Phone]
        public string? Telefon { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime CalismaSaatleri { get; set; }
        public int HizmetID { get; set; }
        public Hizmet? Hizmet { get; set; }//bir berber bir hizmet verebilir
    }
}