using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.DataAcessLayer.Abstract
{
    public interface ISatısDetayRepository : IRepository<SatısDetay>
    {
        IEnumerable<SatısDetay> GetAllWithUrun();
        IEnumerable<SatısDetay> GetAllWithUrun(int satıs_id);
    }
}
