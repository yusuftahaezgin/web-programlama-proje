using Microsoft.EntityFrameworkCore;

namespace BerberOtomasyonu.Entity
{
    public class Veriler:DbContext
    {
        public Veriler(DbContextOptions<Veriler> options):base(options)
        {
            
        }
        public DbSet<Randevu> Randevular =>Set<Randevu>(); // nullable oldugu icin uyari verir uyariyi engellemek icin set ettik basta

        public DbSet<Musteri> Musteriler =>Set<Musteri>();

        public DbSet<Hizmet> Hizmetler =>Set<Hizmet>();
        public DbSet<Admin> Adminler =>Set<Admin>();
        public DbSet<Berber> Berberler =>Set<Berber>();
    }
}