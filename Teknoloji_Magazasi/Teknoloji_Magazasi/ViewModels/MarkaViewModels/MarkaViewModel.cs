using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.ViewModels.MarkaViewModels
{
    public class MarkaViewModel : BaseViewModel
    {
        private Marka _marka;
        public Marka Marka
        {
            get { return _marka; }
        }

        public int Id
        {
            get { return _marka.Id; }
            set
            {
                if (_marka.Id != value)
                {
                    _marka.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ad
        {
            get { return _marka.Ad; }
            set
            {
                if (_marka.Ad != value)
                {
                    _marka.Ad = value;
                    OnPropertyChanged();
                }
            }
        }

        public MarkaViewModel() : this(new Marka()) { }
        public MarkaViewModel(Marka marka)
        {
            this._marka = marka;
        }
    }
}
