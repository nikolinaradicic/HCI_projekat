using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object grdLoadXAML;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
                (sender as Button).ContextMenu.IsEnabled = true;
                (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
                (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                (sender as Button).ContextMenu.IsOpen = true;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = RasporedPage.getInstance();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = UcionicePage.getInstance();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = PredmetiPage.getInstance();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = SoftverPage.getInstance();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = SmjeroviPage.getInstance();
        }
    }
}
