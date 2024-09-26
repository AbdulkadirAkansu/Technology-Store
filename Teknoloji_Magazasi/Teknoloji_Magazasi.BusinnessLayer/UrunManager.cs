using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.DataAcessLayer;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.BusinnessLayer
{
    public class UrunManager : IDisposable
    {
        private UnitOfWork work;
        public UrunManager()
        {
            work = new UnitOfWork();
        }

        public List<Urun> Listele()
        {
            return work.UrunRepo.GetAllWithMarka().ToList();
        }

        public Urun GetUrun(int id)
        {
            return work.UrunRepo.GetItemWithMarka(id);
        }
        public Urun GetUrun(string barkod)
        {
            return work.UrunRepo.GetItemWithMarka(barkod);
        }

        public int Ekle(Urun urun)
        {
            if (work.UrunRepo.GetItemWithMarka(urun.Barkod) != null)
                throw new ArgumentException(urun.Barkod + " barkodlu ürün zaten var...");
            work.UrunRepo.Add(urun);
            return work.Save();
        }

        public int Sil(int id)
        {
            work.UrunRepo.Remove(id);
            return work.Save();

        }
        public int Sil(Urun urun)
        {
            work.UrunRepo.Remove(urun);
            return work.Save();
        }

        public int Guncelle(string oldBarkod, Urun urun)
        {
            if (urun.Barkod != oldBarkod)
            {
                if (work.UrunRepo.GetItemWithMarka(urun.Barkod) != null)
                    throw new ArgumentException(urun.Barkod + " barkodlu ürün zaten var...");
            }
            work.UrunRepo.Update(urun);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
