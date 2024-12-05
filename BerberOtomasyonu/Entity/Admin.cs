using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required]
        [MaxLength(50)]
        public string KullaniciAdi { get; set; }=null!;

        [Required]
        public string Sifre { get; set; }=null!;

        [Required]
        [MaxLength(50)]
        public string? AdSoyad { get; set; }

        [EmailAddress]
        public string? Eposta { get; set; }

        [Phone]
        public string? Telefon { get; set; }
    }
}