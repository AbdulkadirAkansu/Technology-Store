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
    public class SatısDetayRepository : Repository<SatısDetay>, ISatısDetayRepository
    {
        public SatısDetayRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SatısDetay> GetAllWithUrun()
        {
            return context.Set<SatısDetay>().Include(x => x.Urun).ToList();
        }

        public IEnumerable<SatısDetay> GetAllWithUrun(int satıs_id)
        {
            return context.Set<SatısDetay>().Include(x => x.Urun).Where(x => x.SatısId == satıs_id).ToList();
        }
    }
}
