using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
    public class Berber
    {
        [Key]
        public int BerberID { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdSoyad { get; set; }=null!;

        [Phone]
        public string? Telefon { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string UzmanlikAlani { get; set; }=null!;

        public TimeSpan CalismaSaatleri { get; set; }
    }
}