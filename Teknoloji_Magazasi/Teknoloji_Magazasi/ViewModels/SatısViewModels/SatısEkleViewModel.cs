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
using Teknoloji_Magazasi.ViewModels.SatısDetayViewModels;
using Teknoloji_Magazasi.BusinnessLayer;
using Teknoloji_Magazasi.EntityLayer;

namespace Teknoloji_Magazasi.ViewModels.SatısViewModels
{
    public class SatısEkleViewModel : BaseViewModel
    {
        private UrunManager urunManager;
        private SatısManager satısManager;

        private ObservableCollection<SatısDetayViewModel> items;
        private SatısDetayViewModel selectedItem;
        private string barkod = "";
        private decimal toplamTutar = 0;

        public ObservableCollection<SatısDetayViewModel> Items
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

        public SatısDetayViewModel SelectedItem
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

        public string Barkod
        {
            get { return barkod; }
            set
            {
                if (barkod != value)
                {
                    barkod = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal ToplamTutar
        {
            get { return toplamTutar; }
            set
            {
                if (toplamTutar != value)
                {
                    toplamTutar = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand EkleCommand { get; set; }

        public ICommand TamamlaCommand { get; set; }

        public SatısEkleViewModel()
        {
            satısManager = new SatısManager();
            urunManager = new UrunManager();

            EkleCommand = new RelayCommand(o => { OnEkle(); }, o => { return barkod.Length > 2; });
            TamamlaCommand = new RelayCommand(o => { OnTamamla(); }, o => { return items.Count > 0; });
            items = new ObservableCollection<SatısDetayViewModel>();
        }

        private void OnEkle()
        {
            Urun urun = urunManager.GetUrun(barkod);
            if (urun == null)
            {
                MessageBox.Show(barkod + " barkodlu ürün YOK!!!");
            }
            else
            {
                SatısDetayViewModel detay = items.FirstOrDefault(x => x.Urun.Barkod == barkod);
                if (detay == null)
                {
                    //yeni
                    SatısDetayViewModel item = new SatısDetayViewModel { UrunId = urun.Id, Adet = 1, Tutar = urun.Fiyat, Urun = urun };
                    Items.Add(item);
                }
                else
                {
                    //adet artır
                    detay.Adet++;
                    detay.Tutar += urun.Fiyat;
                }
                ToplamTutar += urun.Fiyat;
            }
            Barkod = "";
        }

        private void OnTamamla()
        {
            Satıs satıs = new Satıs() { TarihSaat = DateTime.Now, ToplamTutar = toplamTutar };
            foreach (var item in items)
            {
                SatısDetay detay = new SatısDetay
                {
                    UrunId = item.Urun.Id,
                    Adet = item.Adet,
                    Tutar = item.Tutar
                };
                satıs.Detaylar.Add(detay);
            }

            if (satısManager.Ekle(satıs) > 0)
            {
                Items.Clear();
                ToplamTutar = 0;
            }
            else
            {
                MessageBox.Show("Satış Eklenemedi...");
            }
        }
    }
}

