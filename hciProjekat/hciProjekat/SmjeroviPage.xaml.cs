using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SmjeroviPage.xaml
    /// </summary>
    public partial class SmjeroviPage : Page
    {
        private SmjeroviPage()
        {

            InitializeComponent();
            this.DataContext = this;
            Smjerovi = Smjer.ucitajSmjerove();
            if (Smjerovi.Count > 0)
            {
                this.dgrSmjerovi.SelectedIndex = 0;
            }
        }

        public ObservableCollection<Smjer> Smjerovi
        {
            get;
            set;
        }
        private static SmjeroviPage instance;

        public static SmjeroviPage getInstance()
        {
            if (instance == null)
            {
                instance = new SmjeroviPage();
            }
            return instance;
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

        private void SoftverBtnClick(object sender, RoutedEventArgs e)
        {
            SoftverPage page = SoftverPage.getInstance();
            NavigationService.Navigate(page);
        }
    }
}
