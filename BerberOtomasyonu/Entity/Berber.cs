using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
    public class Berber
    {
        [Key]
        public int BerberID { get; set; }

        [Required]
        [MaxLength(100)]
        public string AdSoyad { get; set; }=null!;

        [Phone]
        public string? Telefon { get; set; }

        [EmailAddress]
        public string? Eposta { get; set; }

        public string? UzmanlikAlani { get; set; }

        public string? CalismaSaatleri { get; set; }
    }
}