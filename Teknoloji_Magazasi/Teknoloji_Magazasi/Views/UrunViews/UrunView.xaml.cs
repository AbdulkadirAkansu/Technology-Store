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

namespace Teknoloji_Magazasi.Views.UrunViews
{
    /// <summary>
    /// Interaction logic for UrunView.xaml
    /// </summary>
    public partial class UrunView : Window
    {
        public UrunView()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, RoutedEventArgs e)
        {
            txtAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtBarkod.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtFiyat.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtStokAdet.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbxMarka.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();

            DialogResult = true;
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
