using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using Teknoloji_Magazasi.Commons.Commands;
using Teknoloji_Magazasi.ViewModels;
using Teknoloji_Magazasi.BusinnessLayer;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.Views.UrunViews
{
        public class UrunListViewModel : BaseViewModel
        {
            private UrunManager manager;

            private ObservableCollection<UrunViewModel> _items;
            private UrunViewModel _selectedItem;

            public ObservableCollection<UrunViewModel> Items
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

            public UrunViewModel SelectedItem
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

            public UrunListViewModel()
            {
                manager = new UrunManager();
                OnRefresh();

                RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
                InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
                DeleteCommand = new RelayCommand((parameter) => { OnDelete(parameter); }, o => { return _selectedItem != null; });
                UpdateCommand = new RelayCommand((parameter) => { OnUpdate(parameter); }, o => { return _selectedItem != null; });
            }

            private void OnRefresh()
            {
                Items = new ObservableCollection<UrunViewModel>();
                List<Urun> urunler = manager.Listele();
                foreach (var item in urunler)
                {
                    Items.Add(new UrunViewModel(item));
                }
            }

            private void OnInsert()
            {
                UrunViewModel vm = new UrunViewModel();
                UrunView view = new UrunView() { DataContext = vm };
                if (view.ShowDialog() == true)
                {
                    if (manager.Ekle(vm.Urun) > 0)
                    {
                        vm = new UrunViewModel(manager.GetUrun(vm.Barkod));
                        Items.Add(vm);
                    }
                    else
                        MessageBox.Show("Ekleme yapılamadı...");
                }
            }

            private void OnDelete(object parameter)
            {
                UrunViewModel vm = parameter as UrunViewModel;
                if (MessageBox.Show(vm.Ad + " adlı markayı silmek istiyor musunuz?", "Marka Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manager.Sil(vm.Id) > 0)
                    {
                        Items.Remove(vm);
                    }
                    else
                        MessageBox.Show("Silinemedi...");
                }
            }

            private void OnUpdate(object parameter)
            {
                UrunViewModel vm = parameter as UrunViewModel;
                string oldBarkod = vm.Urun.Barkod;
                UrunView view = new UrunView { DataContext = vm };
                if (view.ShowDialog() == true)
                {
                    if (manager.Guncelle(oldBarkod, vm.Urun) == 0)
                        MessageBox.Show("Güncelleme Yapılamadı...");
                    else
                        vm = new UrunViewModel(manager.GetUrun(vm.Barkod));
                }
            }

        }
    }
