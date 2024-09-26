using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teknoloji_Magazasi.BusinnessLayer;
using Teknoloji_Magazasi.Commons.Commands;
using Teknoloji_Magazasi.EntityLayer;
using Teknoloji_Magazasi.ViewModels.SatısDetayViewModels;
using Teknoloji_Magazasi.Views.SatısDetayViews;

namespace Teknoloji_Magazasi.ViewModels.SatısViewModels
{
    public class SatısListViewModel : BaseViewModel
    {
        private ObservableCollection<Satıs> items;
        private Satıs selectedItem;

        public ObservableCollection<Satıs> Items
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

        public Satıs SelectedItem
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

        public ICommand RefreshCommand { get; set; }
        public ICommand DetayCommand { get; set; }

        public SatısListViewModel()
        {
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            DetayCommand = new RelayCommand((parameter) => { OnDetay(parameter); }, (parameter) => { return parameter != null; });
        }

        private void OnRefresh()
        {
            using (SatısManager manager = new SatısManager())
            {
                Items = new ObservableCollection<Satıs>(manager.Listele());
            }
        }

        private void OnDetay(object parameter)
        {
            Satıs satıs = parameter as Satıs;
            using (SatısDetayManager manager = new SatısDetayManager())
            {
                SatısDetayListViewModel vm = new SatısDetayListViewModel(manager.Listele(satıs.SatısId));
                SatısDetayListView view = new SatısDetayListView() { DataContext = vm };
                view.ShowDialog();
            }
        }
    }
}
