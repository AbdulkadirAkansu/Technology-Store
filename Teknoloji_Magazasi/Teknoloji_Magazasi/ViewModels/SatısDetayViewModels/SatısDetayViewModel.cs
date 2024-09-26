using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.ViewModels.SatısDetayViewModels
{
    public class SatısDetayViewModel : BaseViewModel
    {
        private SatısDetay _detay;
        public SatısDetay Detay
        {
            get { return _detay; }
        }

        public int Id
        {
            get { return _detay.Id; }
            set
            {
                if (_detay.Id != value)
                {
                    _detay.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public int UrunId
        {
            get { return _detay.UrunId; }
            set
            {
                if (_detay.UrunId != value)
                {
                    _detay.UrunId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Urun Urun
        {
            get { return _detay.Urun; }
            set
            {
                if (_detay.Urun != value)
                {
                    _detay.Urun = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Adet
        {
            get { return _detay.Adet; }
            set
            {
                if (_detay.Adet != value)
                {
                    _detay.Adet = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Tutar
        {
            get { return _detay.Tutar; }
            set
            {
                if (_detay.Tutar != value)
                {
                    _detay.Tutar = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SatısId
        {
            get { return _detay.SatısId; }
            set
            {
                if (_detay.SatısId != value)
                {
                    _detay.SatısId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Satıs Satıs
        {
            get { return _detay.Satıs; }
            set
            {
                if (_detay.Satıs != value)
                {
                    _detay.Satıs = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatısDetayViewModel() : this(new SatısDetay()) { }
        public SatısDetayViewModel(SatısDetay detay)
        {
            this._detay = detay;
        }
    }
}
