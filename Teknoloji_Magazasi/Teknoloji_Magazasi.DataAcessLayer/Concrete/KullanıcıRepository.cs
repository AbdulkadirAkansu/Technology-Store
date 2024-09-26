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
    public class KullanıcıRepository : Repository<Kullanıcı>, IKullanıcıRepository
    {
        public KullanıcıRepository(DbContext context) : base(context)
        {
        }

        public bool Login(string eposta, string parola)
        {
            return (context.Set<Kullanıcı>().FirstOrDefault(x => x.EPosta.ToLower().Equals(eposta.ToLower()) && x.Parola.Equals(parola)) != null);
        }
    }
}
