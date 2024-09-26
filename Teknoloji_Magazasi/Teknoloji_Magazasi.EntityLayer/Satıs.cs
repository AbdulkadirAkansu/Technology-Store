using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoloji_Magazasi.EntityLayer
{
    [Table("tblSatıslar")]
    public class Satıs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SatısId { get; set; }
        public DateTime TarihSaat { get; set; }
        public decimal ToplamTutar { get; set; }

        public ICollection<SatısDetay> Detaylar { get; set; }
        public Satıs()
        {
            Detaylar = new List<SatısDetay>();
        }
    }
}
