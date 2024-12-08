using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Entity
{
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }
        [Required]
        [MaxLength(20)]
        public string KullaniciAdi { get; set; } =null!;

        [Required]
        [MaxLength(50)]
        public string AdSoyad { get; set; } =null!;

        [Phone]
        public string? Telefon { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Sifre { get; set; }=null!;
        
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}