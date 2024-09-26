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

namespace Teknoloji_Magazasi.Views.KullanıcıViews
{
    /// <summary>
    /// Interaction logic for KullanıcıView.xaml
    /// </summary>
    public partial class KullanıcıView : Window
    {
        public KullanıcıView()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            txtAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtSoyad.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtEPosta.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtParola.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbxYetki.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();

            DialogResult = true;

        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
