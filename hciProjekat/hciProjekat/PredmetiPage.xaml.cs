using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class PredmetiPage : Page, INotifyPropertyChanged
    {
        private PredmetiPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Predmeti = Predmet.ucitajPredmete();
            if (Predmeti.Count > 0)
            {
                SelectedPredmet = Predmeti[0];
                EnableIzbrisi = true;
                EnableIzmijeni = true;
            }
            RezimPregled = true;
            gridPredmeti.IsEnabled = false;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajPredmet.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

        private static PredmetiPage instance;

        private int indexSelektovanog;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private bool rezimPregled;
        public bool RezimPregled
        {
            get
            {
                return rezimPregled;
            }
            set
            {
                if (rezimPregled != value)
                {
                    rezimPregled = value;
                    OnPropertyChanged("RezimPregled");
                }
            }
        }
        private Predmet selectedPredmet;
        public Predmet SelectedPredmet
        {
            get
            {
                return selectedPredmet;
            }
            set
            {
                if (selectedPredmet != value)
                {
                    selectedPredmet = value;
                    OnPropertyChanged("SelectedPredmet");
                }
            }
        }

        private bool enableIzbrisi;
        public bool EnableIzbrisi
        {
            get
            {
                return enableIzbrisi;
            }
            set
            {
                if (enableIzbrisi != value)
                {
                    enableIzbrisi = value;
                    OnPropertyChanged("EnableIzbrisi");
                }
            }
        }

        private bool enableIzmijeni;
        public bool EnableIzmijeni
        {
            get
            {
                return enableIzmijeni;
            }
            set
            {
                if (enableIzmijeni != value)
                {
                    enableIzmijeni = value;
                    OnPropertyChanged("EnableIzmijeni");
                }
            }
        }

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
        


        public void DodajPredmet()
        {

            SelectedPredmet = new Predmet();
            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            Odustani.Visibility = Visibility.Visible;
            SacuvajPredmet.Visibility = Visibility.Visible;
            gridPredmeti.IsEnabled = true;

        }

        public void IzmijeniPredmet()
        {

            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            indexSelektovanog = Predmeti.IndexOf(selectedPredmet);
            SelectedPredmet = new Predmet(selectedPredmet.Id, SelectedPredmet.Naziv, selectedPredmet.Opis,
                selectedPredmet.VelicinaGrupe, selectedPredmet.MinDuzinaTermina, selectedPredmet.BrojTermina,
                selectedPredmet.Projektor, selectedPredmet.Tabla, selectedPredmet.PametnaTabla, selectedPredmet.Smjer,
                selectedPredmet.NeophodanOS, selectedPredmet.NeophodanSoftver);

            gridPredmeti.IsEnabled = true;
            SacuvajIzmjenu.Visibility = Visibility.Visible;
            IzmjenaOdustani.Visibility = Visibility.Visible;

        }

        private void SacuvajPredmet_Click(object sender, RoutedEventArgs e)
        {
            Predmeti.Add(SelectedPredmet);

            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridPredmeti.IsEnabled = false;

            Predmet.sacuvajPredmete(Predmeti.ToList());

            var item = dgrPredmeti.Items[Predmeti.Count - 1];
            dgrPredmeti.SelectedItem = item;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajPredmet.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void SacuvajIzmjenu_Click(object sender, RoutedEventArgs e)
        {
            Predmeti[indexSelektovanog] = SelectedPredmet;
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridPredmeti.IsEnabled = false;

            Predmet.sacuvajPredmete(Predmeti.ToList());
            var item = dgrPredmeti.Items[indexSelektovanog];
            dgrPredmeti.SelectedItem = item;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

        private void IzmjenaOdustani_Click(object sender, RoutedEventArgs e)
        {
            SelectedPredmet = Predmeti[indexSelektovanog];
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridPredmeti.IsEnabled = false;

            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            if (Predmeti.Count > 0)
            {
                SelectedPredmet = Predmeti[0];
                var item = dgrPredmeti.Items[0];
                dgrPredmeti.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedPredmet = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }
            RezimPregled = true;
            gridPredmeti.IsEnabled = false;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajPredmet.Visibility = Visibility.Hidden;

        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            Predmeti.Remove(SelectedPredmet);
            if (Predmeti.Count > 0)
            {
                SelectedPredmet = Predmeti[0];
                var item = dgrPredmeti.Items[0];
                dgrPredmeti.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedPredmet = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }

        }
    }
}
