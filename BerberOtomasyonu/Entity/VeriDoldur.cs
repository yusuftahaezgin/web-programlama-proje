using Microsoft.EntityFrameworkCore;

namespace BerberOtomasyonu.Entity
{
    public static class VeriDoldur // nesne turetmek zorunda olunmasın diye static yaptim
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<Veriler>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Musteriler.Any())
                {
                    context.Musteriler.AddRange(
                        new Musteri { KullaniciAdi = "yusuftahaezgin", AdSoyad = "Yusuf Taha Ezgin", Email = "g221210008@sakarya.edu.tr", Sifre="sau"},
                        new Musteri { KullaniciAdi = "asimbingol", AdSoyad = "Asım Bingöl", Email = "asim@sakarya.edu.tr", Sifre="1234"},
                        new Musteri { KullaniciAdi = "ahmetselvi", AdSoyad = "Ahmet Selvi", Email = "ahmet@sakarya.edu.tr", Sifre="12345"}
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}