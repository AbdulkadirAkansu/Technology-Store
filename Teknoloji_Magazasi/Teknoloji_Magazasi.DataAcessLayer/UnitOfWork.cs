using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.DataAcessLayer.Concrete;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.DataAcessLayer
{
    public class UnitOfWork : IDisposable
    {
        private DatabeseContext context;

        private UrunRepository urun_repo;
        private Repository<Marka> marka_repo;
        private Repository<Satıs> satıs_repo;
        private SatısDetayRepository satısDetay_repo;
        private KullanıcıRepository kullanıcı_repo;

        public UrunRepository UrunRepo
        {
            get
            {
                if (urun_repo == null)
                    urun_repo = new UrunRepository(context);
                return urun_repo;
            }
        }

        public Repository<Marka> MarkaRepo
        {
            get
            {
                if (marka_repo == null)
                    marka_repo = new Repository<Marka>(context);
                return marka_repo;
            }
        }

        public Repository<Satıs> SatısRepo
        {
            get
            {
                if (satıs_repo == null)
                    satıs_repo = new Repository<Satıs>(context);
                return satıs_repo;
            }
        }

        public SatısDetayRepository SatısDetayRepo
        {
            get
            {
                if (satısDetay_repo == null)
                    satısDetay_repo = new SatısDetayRepository(context);
                return satısDetay_repo;
            }
        }

        public KullanıcıRepository KullanıcıRepo
        {
            get
            {
                if (kullanıcı_repo == null)
                    kullanıcı_repo = new KullanıcıRepository(context);
                return kullanıcı_repo;
            }
        }

        public UnitOfWork()
        {
            context = new DatabeseContext();
        }

        public int Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    int adet = context.SaveChanges();
                    transaction.Commit();
                    return adet;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            urun_repo?.Dispose();
            marka_repo?.Dispose();
            kullanıcı_repo?.Dispose();
            satıs_repo?.Dispose();
            satısDetay_repo?.Dispose();
            context?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}