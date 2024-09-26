using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Teknoloji_Magazasi.Commons.Commands;
using Teknoloji_Magazasi.BusinnessLayer;
using Teknoloji_Magazasi.EntityLayer;
using Teknoloji_Magazasi.Views.MarkaViews;

namespace Teknoloji_Magazasi.ViewModels.MarkaViewModels
{
    public class MarkaListViewModel : BaseViewModel
    {
        private MarkaManager manager;

        private ObservableCollection<MarkaViewModel> _items;
        private MarkaViewModel _selectedItem;

        public ObservableCollection<MarkaViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        public MarkaViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public MarkaListViewModel()
        {
            manager = new MarkaManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<MarkaViewModel>();
            List<Marka> markalar = manager.Listele();
            foreach (var item in markalar)
            {
                Items.Add(new MarkaViewModel(item));
            }
        }

        private void OnInsert()
        {
            MarkaViewModel vm = new MarkaViewModel();
            MarkaView view = new MarkaView() { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Ekle(vm.Marka) > 0)
                {
                    Items.Add(vm);
                }
                else
                    MessageBox.Show("Ekleme yapılamadı...");
            }
        }

        private void OnDelete(object parameter)
        {
            MarkaViewModel vm = parameter as MarkaViewModel;
            if (MessageBox.Show(vm.Ad + " adlı markayı silmek istiyor musunuz?", "Marka Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Sil(vm.Marka.Id) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }

        private void OnUpdate(object parameter)
        {
            MarkaViewModel vm = parameter as MarkaViewModel;
            MarkaView view = new MarkaView { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Guncelle(vm.Marka) == 0)
                    MessageBox.Show("Güncelleme Yapılamadı...");
            }
        }
    }
}
