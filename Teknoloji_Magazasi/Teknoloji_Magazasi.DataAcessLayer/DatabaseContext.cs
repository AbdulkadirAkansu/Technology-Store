using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.DataAcessLayer
{
    public class DatabeseContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Satıs> Satıslar { get; set; }
        public DbSet<SatısDetay> SatısDetaylar { get; set; }
        public DatabeseContext() : base("TeknolojiMagazasiDB")
        {
            Database.SetInitializer<DatabeseContext>(new CreateDatabaseIfNotExists<DatabeseContext>());
        }
    }
}
