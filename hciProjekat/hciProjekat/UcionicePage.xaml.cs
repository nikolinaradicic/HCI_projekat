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
    /// Interaction logic for UcionicePage.xaml
    /// </summary>
    public partial class UcionicePage : Page
    {
        private UcionicePage()
        {
            InitializeComponent();
            this.DataContext = this;
            Ucionice = Ucionica.ucitajUcionice();
            if (Ucionice.Count > 0)
            {
                this.dgrUcionice.SelectedIndex = 0;
            }
        }

        private static UcionicePage instance;

        public static UcionicePage getInstance()
        {
            if (instance == null)
            {
                instance = new UcionicePage();
            }
            return instance;
        }

        public ObservableCollection<Ucionica> Ucionice
        {
            get;
            set;
        }

        private void PredmetiBtnClick(object sender, RoutedEventArgs e)
        {
            PredmetiPage page = PredmetiPage.getInstance();
            NavigationService.Navigate(page);
        }

        private void SoftverBtnClick(object sender, RoutedEventArgs e)
        {
            SoftverPage page = SoftverPage.getInstance();
            NavigationService.Navigate(page);
        }

        private void SmjeroviBtnClick(object sender, RoutedEventArgs e)
        {
            SmjeroviPage page = SmjeroviPage.getInstance();
            NavigationService.Navigate(page);
        }
    }
}
