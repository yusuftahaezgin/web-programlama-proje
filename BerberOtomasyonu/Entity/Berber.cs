using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int HizmetID { get; set; }

        [Required]
        public TimeSpan CalismaBaslangic { get; set; } = new TimeSpan(9, 0, 0);

        [Required]
        public TimeSpan CalismaBitis { get; set; } = new TimeSpan(17, 0, 0);
        public ICollection<Hizmet> Hizmetler { get; set; }= new List<Hizmet>();
    }
}