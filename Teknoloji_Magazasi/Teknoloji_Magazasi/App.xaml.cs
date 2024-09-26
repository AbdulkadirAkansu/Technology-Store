using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Teknoloji_Magazasi.EntityLayer;
using Teknoloji_Magazasi.Views.KullanıcıViews;
using Teknoloji_Magazasi.Views.SatısViews;

namespace Teknoloji_Magazasi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Kullanıcı Kullanıcı { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window mudurMain = new MainWindow();
            Window kasiyerMain = new SatısEkleView();

            LoginView view = new LoginView();
            if (view.ShowDialog() == true)
            {

                if (Kullanıcı.Yetki == Yetkiler.Mudur)
                {
                    MainWindow = mudurMain;
                    kasiyerMain.Close();
                }
                else
                {
                    MainWindow = kasiyerMain;
                    mudurMain.Close();
                }

                MainWindow.Show();
            }

        }
    }
}