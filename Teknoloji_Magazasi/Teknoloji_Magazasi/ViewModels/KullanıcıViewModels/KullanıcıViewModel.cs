using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.ViewModels.KullanıcıViewModels
{
    public class KullanıcıViewModel : BaseViewModel
    {
        private Kullanıcı _kullanıcı;
        public Kullanıcı Kullanıcı
        {
            get { return _kullanıcı; }
        }

        public string EPosta
        {
            get { return _kullanıcı.EPosta; }
            set
            {
                if (_kullanıcı.EPosta != value)
                {
                    _kullanıcı.EPosta = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Parola
        {
            get { return _kullanıcı.Parola; }
            set
            {
                if (_kullanıcı.Parola != value)
                {
                    _kullanıcı.Parola = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _kullanıcı.Ad; }
            set
            {
                if (_kullanıcı.Ad != value)
                {
                    _kullanıcı.Ad = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Soyad
        {
            get { return _kullanıcı.Soyad; }
            set
            {
                if (_kullanıcı.Soyad != value)
                {
                    _kullanıcı.Soyad = value;
                    OnPropertyChanged();
                }
            }
        }

        public Yetkiler Yetki
        {
            get { return _kullanıcı.Yetki; }
            set
            {
                if (_kullanıcı.Yetki != value)
                {
                    _kullanıcı.Yetki = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Yetkiler> yetkiler;
        public ObservableCollection<Yetkiler> Yetkiler
        {
            get { return yetkiler; }
            set
            {
                if (yetkiler != value)
                {
                    yetkiler = value;
                    OnPropertyChanged();
                }
            }
        }

        public KullanıcıViewModel() : this(new Kullanıcı()) { }
        public KullanıcıViewModel(Kullanıcı kullanıcı)
        {
            this._kullanıcı = kullanıcı;
            yetkiler = new ObservableCollection<Yetkiler> { EntityLayer.Yetkiler.Kasiyer, EntityLayer.Yetkiler.Mudur };
        }
    }
}
