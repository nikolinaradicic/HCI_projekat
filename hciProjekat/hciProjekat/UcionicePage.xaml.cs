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
    /// Interaction logic for UcionicePage.xaml
    /// </summary>
    public partial class UcionicePage : Page, INotifyPropertyChanged
    {
        private UcionicePage()
        {
            InitializeComponent();
            this.DataContext = this;
            Ucionice = Ucionica.ucitajUcionice();
            if (Ucionice.Count > 0)
            {
                SelectedUcionica = Ucionice[0];
                EnableIzbrisi = true;
                EnableIzmijeni = true;
            }
            RezimPregled = true;
            gridUcionice.IsEnabled = false;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajUcionicu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

        private static UcionicePage instance;

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
        private Ucionica selectedUcionica;
        public Ucionica SelectedUcionica
        {
            get
            {
                return selectedUcionica;
            }
            set
            {
                if (selectedUcionica != value)
                {
                    selectedUcionica = value;
                    OnPropertyChanged("SelectedUcionica");
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


        public void DodajUcionicu()
        {

            SelectedUcionica = new Ucionica();
            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            Odustani.Visibility = Visibility.Visible;
            SacuvajUcionicu.Visibility = Visibility.Visible;
            gridUcionice.IsEnabled = true;

        }

        public void IzmijeniUcionicu()
        {

            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            indexSelektovanog = Ucionice.IndexOf(SelectedUcionica);
            SelectedUcionica = new Ucionica(SelectedUcionica.Id, SelectedUcionica.Opis, SelectedUcionica.BrojMjesta,
                SelectedUcionica.Projektor, SelectedUcionica.Tabla, SelectedUcionica.PametnaTabla, SelectedUcionica.InstaliraniSoftver,
                SelectedUcionica.InstaliranOS);

            gridUcionice.IsEnabled = true;
            SacuvajIzmjenu.Visibility = Visibility.Visible;
            IzmjenaOdustani.Visibility = Visibility.Visible;

        }

        private void SacuvajUcionicu_Click(object sender, RoutedEventArgs e)
        {
            Ucionice.Add(SelectedUcionica);

            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridUcionice.IsEnabled = false;

            Ucionica.sacuvajUcionice(Ucionice.ToList());

            var item = dgrUcionice.Items[Ucionice.Count - 1];
            dgrUcionice.SelectedItem = item;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajUcionicu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void SacuvajIzmjenu_Click(object sender, RoutedEventArgs e)
        {
            Ucionice[indexSelektovanog] = SelectedUcionica;
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridUcionice.IsEnabled = false;

            Ucionica.sacuvajUcionice(Ucionice.ToList());
            var item = dgrUcionice.Items[indexSelektovanog];
            dgrUcionice.SelectedItem = item;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

        private void IzmjenaOdustani_Click(object sender, RoutedEventArgs e)
        {
            SelectedUcionica = Ucionice[indexSelektovanog];
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridUcionice.IsEnabled = false;

            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            if (Ucionice.Count > 0)
            {
                SelectedUcionica = Ucionice[0];
                var item = dgrUcionice.Items[0];
                dgrUcionice.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedUcionica = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }
            RezimPregled = true;
            gridUcionice.IsEnabled = false;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajUcionicu.Visibility = Visibility.Hidden;

        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            Ucionice.Remove(SelectedUcionica);
            if (Ucionice.Count > 0)
            {
                SelectedUcionica = Ucionice[0];
                var item = dgrUcionice.Items[0];
                dgrUcionice.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedUcionica = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }

        }

        private void Izaberi_Click(object sender, RoutedEventArgs e)
        {
            IzborViseSoftvera izbor = new IzborViseSoftvera(SelectedUcionica.InstaliraniSoftver);
            izbor.Show();
        }
    }
}
