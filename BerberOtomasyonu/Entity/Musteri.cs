using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }

        [Required]
        [MaxLength(100)]
        public string AdSoyad { get; set; } =null!;

        [Phone]
        public string? Telefon { get; set; }

        [EmailAddress]
        public string? Eposta { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}