using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.DataAcessLayer.Abstract
{
    public interface IUrunRepository : IRepository<Urun>
    {
        IEnumerable<Urun> GetAllWithMarka();
        Urun GetItemWithMarka(string barkod);
        Urun GetItemWithMarka(int id);
    }
}
