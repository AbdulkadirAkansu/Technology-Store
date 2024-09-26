using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.DataAcessLayer;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.BusinnessLayer
{
    public class SatısManager : IDisposable
    {

        private UnitOfWork work;
        public SatısManager()
        {
            work = new UnitOfWork();
        }

        public List<Satıs> Listele()
        {
            return work.SatısRepo.GetAll().ToList();
        }

        public int Ekle(Satıs satıs)
        {
            foreach (var detay in satıs.Detaylar)
            {
                Urun urun = work.UrunRepo.GetItem(detay.UrunId);
                urun.StokAdet -= detay.Adet;
                work.UrunRepo.Update(urun);
            }
            work.SatısRepo.Add(satıs);
            return work.Save();
        }

        public int Sil(int id)
        {
            work.SatısRepo.Remove(id);
            return work.Save();
        }

        public int Sil(Satıs satıs)
        {
            work.SatısRepo.Remove(satıs);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
