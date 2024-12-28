using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerberOtomasyonu.Entity
{
    public class Hizmet
    {
        [Key]
        public int HizmetID { get; set; }

        [Required]
        [MaxLength(100)]
        public string HizmetAdi { get; set; }=null!;
        public string? Aciklama { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public int Fiyat { get; set; }
        public ICollection<Berber> Berberler { get; set; }=new List<Berber>(); //bir hizmeti birden fazla berber verebilir
    }
}