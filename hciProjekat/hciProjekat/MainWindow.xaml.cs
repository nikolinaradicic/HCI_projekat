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

        public MainWindow()
        {
            InitializeComponent();
            SoftverPage.getInstance();
            SmjeroviPage.getInstance();
            PredmetiPage.getInstance();
            UcionicePage.getInstance();
            
        }

        private string active;
        
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
            active = "raspored";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = UcionicePage.getInstance();
            active = "ucionice";
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = PredmetiPage.getInstance();
            active = "predmeti";
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = SoftverPage.getInstance();
            active = "softveri";
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = SmjeroviPage.getInstance();
            active = "smjerovi";
        }

        private void DodajSoftver_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (active.Equals("softveri"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void DodajSoftver_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            SoftverPage page = (SoftverPage)MainFrame.Content;
            if(page.RezimPregled)
                page.dodajSoftver();

        }

        private void IzmijeniSoftver_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (active.Equals("softveri"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void IzmijeniSoftver_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SoftverPage page = (SoftverPage)MainFrame.Content;
            if(page.EnableIzmijeni)
                page.IzmijeniSoftver();

        }


        private void DodajSmjer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (active.Equals("smjerovi"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void DodajSmjer_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SmjeroviPage page = (SmjeroviPage)MainFrame.Content;
            if(page.RezimPregled)
                page.dodajSmjer();

        }

        private void IzmijeniSmjer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (active.Equals("smjerovi"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void IzmijeniSmjer_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            SmjeroviPage page = (SmjeroviPage)MainFrame.Content;
            if(page.EnableIzmijeni)
                page.izmijeniSmjer();

        }


        private void DodajPredmet_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (active.Equals("predmeti"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void DodajPredmet_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PredmetiPage page = (PredmetiPage)MainFrame.Content;
            if(page.RezimPregled)
                page.DodajPredmet();
        }

        private void IzmijeniPredmet_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (active.Equals("predmeti"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void IzmijeniPredmet_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PredmetiPage page = (PredmetiPage)MainFrame.Content;
            if(page.EnableIzmijeni)
                page.IzmijeniPredmet();

        }

        private void DodajUcionicu_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (active.Equals("ucionice"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void DodajUcionicu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UcionicePage page = (UcionicePage)MainFrame.Content;
            if(page.RezimPregled)
                page.DodajUcionicu();
        }

        private void IzmijeniUcionicu_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if (active.Equals("ucionice"))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void IzmijeniUcionicu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UcionicePage page = (UcionicePage)MainFrame.Content;
            if (page.EnableIzmijeni)
                page.IzmijeniUcionicu();

        }
    }
}
