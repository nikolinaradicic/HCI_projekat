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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hciProjekat
{
    /// <summary>
    /// Interaction logic for PredmetiPage.xaml
    /// </summary>
    public partial class PredmetiPage : Page
    {
        public PredmetiPage()
        {
            InitializeComponent();
        }

        private void SoftverBtnClick(object sender, RoutedEventArgs e)
        {
            SoftverPage page = new SoftverPage();
            NavigationService.Navigate(page);
        }

        private void UcioniceBtnClick(object sender, RoutedEventArgs e)
        {
            UcionicePage page = new UcionicePage();
            NavigationService.Navigate(page);
        }

        private void SmjeroviBtnClick(object sender, RoutedEventArgs e)
        {
            SmjeroviPage page = new SmjeroviPage();
            NavigationService.Navigate(page);
        }
    }
}
