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
using Teknoloji_Magazasi.Views.KullanıcıViews;

namespace Teknoloji_Magazasi.ViewModels.KullanıcıViewModels
{
    public class KullanıcıListViewModel : BaseViewModel
    {
        private KullanıcıManager manager;

        private ObservableCollection<KullanıcıViewModel> _items;
        private KullanıcıViewModel _selectedItem;


        public ObservableCollection<KullanıcıViewModel> Items
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

        public KullanıcıViewModel SelectedItem
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

        public KullanıcıListViewModel()
        {
            manager = new KullanıcıManager();
            OnRefresh();

            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
        }

        private void OnRefresh()
        {
            Items = new ObservableCollection<KullanıcıViewModel>();
            List<Kullanıcı> urunler = manager.Listele();
            foreach (var item in urunler)
            {
                Items.Add(new KullanıcıViewModel(item));
            }
        }

        private void OnInsert()
        {
            KullanıcıViewModel vm = new KullanıcıViewModel();
            KullanıcıView view = new KullanıcıView() { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Ekle(vm.Kullanıcı) > 0)
                {
                    Items.Add(vm);
                }
                else
                    MessageBox.Show("Ekleme yapılamadı...");
            }
        }

        private void OnDelete(object parameter)
        {
            KullanıcıViewModel vm = parameter as KullanıcıViewModel;
            if (MessageBox.Show(vm.Ad + " " + vm.Soyad + " adlı kullanıcıyı silmek istiyor musunuz?", "Kullanıcı Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (manager.Sil(vm.EPosta) > 0)
                {
                    Items.Remove(vm);
                }
                else
                    MessageBox.Show("Silinemedi...");
            }
        }

        private void OnUpdate(object parameter)
        {
            KullanıcıViewModel vm = parameter as KullanıcıViewModel;
            string oldEPosta = vm.Kullanıcı.EPosta;
            KullanıcıView view = new KullanıcıView { DataContext = vm };
            if (view.ShowDialog() == true)
            {
                if (manager.Guncelle(oldEPosta, vm.Kullanıcı) == 0)
                    MessageBox.Show("Güncelleme Yapılamadı...");
            }
        }
    }
}
