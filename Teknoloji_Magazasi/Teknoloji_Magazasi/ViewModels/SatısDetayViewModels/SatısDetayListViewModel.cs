using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.ViewModels.SatısDetayViewModels
{
    public class SatısDetayListViewModel : BaseViewModel
    {
        private ObservableCollection<SatısDetay> items;
        private SatısDetay selectedItem;

        public ObservableCollection<SatısDetay> Items
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatısDetay SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public SatısDetayListViewModel(List<SatısDetay> detaylar)
        {
            Items = new ObservableCollection<SatısDetay>(detaylar);
        }
    }
}
