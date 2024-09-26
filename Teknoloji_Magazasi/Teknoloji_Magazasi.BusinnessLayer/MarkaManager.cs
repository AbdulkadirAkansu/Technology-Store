using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.DataAcessLayer;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.BusinnessLayer
{
    public class MarkaManager : IDisposable
    {
        private UnitOfWork work;

        public MarkaManager()
        {
            work = new UnitOfWork();
        }

        public List<Marka> Listele()
        {
            return work.MarkaRepo.GetAll().ToList();
        }

        public Marka GetMarka(int id)
        {
            return work.MarkaRepo.GetItem(id);
        }

        public int Ekle(Marka marka)
        {
            work.MarkaRepo.Add(marka);

            return work.Save();
        }

        public int Sil(int id)
        {
            work.MarkaRepo.Remove(id);
            return work.Save();
        }

        public int Guncelle(Marka marka)
        {
            work.MarkaRepo.Update(marka);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
