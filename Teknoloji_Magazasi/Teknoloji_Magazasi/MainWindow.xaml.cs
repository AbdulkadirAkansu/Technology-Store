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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Teknoloji_Magazasi.EntityLayer;
using Teknoloji_Magazasi.Views.KullanıcıViews;
using Teknoloji_Magazasi.Views.SatısViews;

namespace Teknoloji_Magazasi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnUrunList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/UrunViews/UrunListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnMarkaList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/MarkaViews/MarkaListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnSatısList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/SatısViews/SatısListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }

        private void btnKullanıcıList_Click(object sender, RoutedEventArgs e)
        {
            mainFrm.Source = new Uri("Views/KullanıcıViews/KullanıcıListView.xaml", UriKind.Relative);
            mainDrawer.IsLeftDrawerOpen = false;
        }
    
    }
}
