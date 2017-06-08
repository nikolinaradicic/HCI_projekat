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
    /// Interaction logic for PredmetiPage.xaml
    /// </summary>
    public partial class PredmetiPage : Page
    {
        private PredmetiPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Predmeti = Predmet.ucitajPredmete();
            if (Predmeti.Count > 0)
            {
                this.dgrPredmeti.SelectedIndex = 0;
            }
        }

        private static PredmetiPage instance;

        public ObservableCollection<Predmet> Predmeti
        {
            get;
            set;
        }

        public static PredmetiPage getInstance()
        {
            if (instance == null)
            {
                instance = new PredmetiPage();
            }
            return instance;
        }


        private void SoftverBtnClick(object sender, RoutedEventArgs e)
        {
            SoftverPage page = SoftverPage.getInstance();
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
