using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Teknoloji_Magazasi.BusinnessLayer;

namespace Teknoloji_Magazasi.Views.KullanıcıViews
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            using (KullanıcıManager manager = new KullanıcıManager())
            {
                if (manager.Login(txtEPosta.Text, txtParola.Password))
                {
                    App.Kullanıcı = manager.GetKullanıcı(txtEPosta.Text);
                    DialogResult = true;
                }
            }
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
