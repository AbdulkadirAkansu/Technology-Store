using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.DataAcessLayer;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.BusinnessLayer
{
    public class KullanıcıManager : IDisposable
    {
        private UnitOfWork work;
        public KullanıcıManager()
        {
            work = new UnitOfWork();
        }

        public bool Login(string eposta, string parola)
        {
            return work.KullanıcıRepo.Login(eposta, parola);
        }

        public List<Kullanıcı> Listele()
        {
            return work.KullanıcıRepo.GetAll().ToList();
        }

        public Kullanıcı GetKullanıcı(string eposta)
        {
            return work.KullanıcıRepo.GetItem(eposta);
        }

        public int Ekle(Kullanıcı kullanıcı)
        {
            if (work.KullanıcıRepo.GetItem(kullanıcı.EPosta) != null)
                throw new ArgumentException(kullanıcı.EPosta + " eposta adresine sahip kullanıcı zaten var...");

            work.KullanıcıRepo.Add(kullanıcı);
            return work.Save();
        }

        public int Sil(Kullanıcı kullanıcı)
        {
            work.KullanıcıRepo.Remove(kullanıcı);
            return work.Save();
        }

        public int Sil(string eposta)
        {
            work.KullanıcıRepo.Remove(eposta);
            return work.Save();
        }

        public int Guncelle(string oldEposta, Kullanıcı kullanıcı)
        {
            if (kullanıcı.EPosta != oldEposta)
            {
                if (work.KullanıcıRepo.GetItem(kullanıcı.EPosta) != null)
                    throw new ArgumentException(kullanıcı.EPosta + " eposta adresine sahip kullanıcı zaten var...");
            }
            work.KullanıcıRepo.Update(kullanıcı);
            return work.Save();
        }

        public void Dispose()
        {
            work?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
