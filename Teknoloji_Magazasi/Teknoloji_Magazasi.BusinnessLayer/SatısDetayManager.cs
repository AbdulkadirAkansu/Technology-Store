using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.DataAcessLayer;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.BusinnessLayer
{
    public class SatısDetayManager : IDisposable
    {
        private UnitOfWork work;
        public SatısDetayManager()
        {
            work = new UnitOfWork();
        }

        public List<SatısDetay> Listele(int satıs_id)
        {
            return work.SatısDetayRepo.GetAllWithUrun(satıs_id).ToList();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
