using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SoftverPage.xaml
    /// </summary>
    public partial class SoftverPage : Page
    {
        private SoftverPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Softveri = Softver.ucitajSoftver();
            if (Softveri.Count > 0)
            {
                this.dgrSoftver.SelectedIndex = 0;
            }

        }

        private static SoftverPage instance;

        public static SoftverPage getInstance()
        {
            if (instance == null)
            {
                instance = new SoftverPage();
            }
            return instance;
        }

        public ObservableCollection<Softver> Softveri
        {
            get;
            set;
        }


        private void PredmetiBtnClick(object sender, RoutedEventArgs e)
        {
            PredmetiPage page = PredmetiPage.getInstance();
            NavigationService.Navigate(page);
        }

        private void UcioniceBtnClick(object sender, RoutedEventArgs e)
        {
            UcionicePage page = UcionicePage.getInstance();
            NavigationService.Navigate(page);
        }

        private void SmjeroviBtnClick(object sender, RoutedEventArgs e)
        {
            SmjeroviPage page = SmjeroviPage.getInstance();
            NavigationService.Navigate(page);
        }
    }
}
