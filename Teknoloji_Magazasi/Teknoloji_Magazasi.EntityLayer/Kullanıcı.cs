using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoloji_Magazasi.EntityLayer
{
    public enum Yetkiler
    {
        Mudur = 1,
        Kasiyer = 2
    }

    [Table("tblKullanıcılar")]
    public class Kullanıcı
    {
        [Key]
        public string EPosta { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Parola { get; set; }
        public Yetkiler Yetki { get; set; }
    }
}
