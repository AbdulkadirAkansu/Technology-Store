using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Teknoloji_Magazasi.BusinnessLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Teknoloji_Magazasi.ViewModels.MarkaViewModels;
using Teknoloji_Magazasi.ViewModels;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.Views.UrunViews
{
    public class UrunViewModel : BaseViewModel
    {
        private Urun _urun;
        public Urun Urun
        {
            get { return _urun; }
        }


        public int Id
        {
            get { return _urun.Id; }
            set
            {
                if (_urun.Id != value)
                {
                    _urun.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Barkod
        {
            get { return _urun.Barkod; }
            set
            {
                if (_urun.Barkod != value)
                {
                    _urun.Barkod = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _urun.Ad; }
            set
            {
                if (_urun.Ad != value)
                {
                    _urun.Ad = value;
                    OnPropertyChanged();
                }
            }
        }

        public int StokAdet
        {
            get { return _urun.StokAdet; }
            set
            {
                if (_urun.StokAdet != value)
                {
                    _urun.StokAdet = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MarkaId
        {
            get { return _urun.MarkaId; }
            set
            {
                if (_urun.MarkaId != value)
                {
                    _urun.MarkaId = value;
                    Marka = new MarkaViewModel(markalar.First(x => x.Id == _urun.MarkaId));
                    OnPropertyChanged();
                }
            }
        }

        private MarkaViewModel _marka;
        public MarkaViewModel Marka
        {
            get { return _marka; }
            set
            {
                if (_marka != value)
                {
                    _marka = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Fiyat
        {
            get { return _urun.Fiyat; }
            set
            {
                if (_urun.Fiyat != value)
                {
                    _urun.Fiyat = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Marka> markalar;
        public ObservableCollection<Marka> Markalar
        {
            get { return markalar; }
            set
            {
                if (markalar != value)
                {
                    markalar = value;
                    OnPropertyChanged();
                }
            }
        }

        public UrunViewModel() : this(new Urun()) { }
        public UrunViewModel(Urun urun)
        {
            this._urun = urun;
            this._marka = new MarkaViewModel(urun.Marka);

            using (MarkaManager manager = new MarkaManager())
            {
                Markalar = new ObservableCollection<Marka>(manager.Listele());
            }
        }
    }
}

