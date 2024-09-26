using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.DataAcessLayer.Abstract;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.DataAcessLayer.Concrete
{
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<Urun> GetAllWithMarka()
        {
            return context.Set<Urun>().Include(x => x.Marka).ToList();
        }

        public Urun GetItemWithMarka(string barkod)
        {
            return context.Set<Urun>().Include(x => x.Marka).FirstOrDefault(x => x.Barkod.Equals(barkod));
        }

        public Urun GetItemWithMarka(int id)
        {
            return context.Set<Urun>().Include(x => x.Marka).FirstOrDefault(x => x.Id == id);
        }
    }
}
