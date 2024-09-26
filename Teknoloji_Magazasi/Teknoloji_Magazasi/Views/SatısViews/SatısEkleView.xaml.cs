﻿using System;
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
using Teknoloji_Magazasi.ViewModels.SatısViewModels;

namespace Teknoloji_Magazasi.Views.SatısViews
{
    /// <summary>
    /// Interaction logic for SatısEkleView.xaml
    /// </summary>
    public partial class SatısEkleView : Window
    {
        public SatısEkleView()
        {
            InitializeComponent();
            DataContext = new SatısEkleViewModel();
        }
    }
}
