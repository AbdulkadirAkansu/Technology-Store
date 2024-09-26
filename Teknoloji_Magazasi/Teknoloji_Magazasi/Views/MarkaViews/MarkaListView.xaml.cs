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
using Teknoloji_Magazasi.ViewModels.MarkaViewModels;

namespace Teknoloji_Magazasi.Views.MarkaViews
{
    /// <summary>
    /// Interaction logic for MarkaListView.xaml
    /// </summary>
    public partial class MarkaListView : Page
    {
        public MarkaListView()
        {
            InitializeComponent();
            DataContext = new MarkaListViewModel();
        }
    }
}
