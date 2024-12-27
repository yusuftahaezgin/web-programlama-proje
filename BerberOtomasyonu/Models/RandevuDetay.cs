namespace BerberOtomasyonu.Models
{
    public class RandevuDetay
{
    public int RandevuID { get; set; }
    public string HizmetAdi { get; set; }
    public string BerberAdi { get; set; }
    public DateTime RandevuTarihi { get; set; }
    public string RandevuSaati { get; set; }
    public bool Durum { get; set; }
}
}

