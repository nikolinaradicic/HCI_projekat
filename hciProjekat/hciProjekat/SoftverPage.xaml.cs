using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class SoftverPage : Page, INotifyPropertyChanged
    {
        private SoftverPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Softveri = Softver.ucitajSoftver();
            if (Softveri.Count > 0)
            {
                SelectedSoftver = Softveri[0];
                EnableIzbrisi = true;
                EnableIzmijeni = true;
            }
            RezimPregled = true;
            gridSoftver.IsEnabled = false;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajSoftver.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

        private int indexSelektovanog;
        private static SoftverPage instance;

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
        private Softver selectedSoftver;
        public Softver SelectedSoftver
        {
        get
        {
            return selectedSoftver;
        }
        set
        {
            if (selectedSoftver != value)
            {
                selectedSoftver = value;
                OnPropertyChanged("SelectedSoftver");
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

        internal void IzmijeniSoftver()
        {
            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            indexSelektovanog = Softveri.IndexOf(selectedSoftver);
            SelectedSoftver = new Softver(selectedSoftver.Id, selectedSoftver.Naziv, selectedSoftver.Proizvodjac, selectedSoftver.Sajt,
                selectedSoftver.GodinaIzdavanja, selectedSoftver.Cijena, selectedSoftver.Opis, selectedSoftver.OperativniSistem);

            gridSoftver.IsEnabled = true;
            SacuvajIzmjenu.Visibility = Visibility.Visible;
            IzmjenaOdustani.Visibility = Visibility.Visible;

        }

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
        

        public void dodajSoftver()
        {

            SelectedSoftver = new Softver();
            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            Odustani.Visibility = Visibility.Visible;
            SacuvajSoftver.Visibility = Visibility.Visible;
            gridSoftver.IsEnabled = true;
        }

        private void SacuvajSoftver_Click(object sender, RoutedEventArgs e)
        {
            Softveri.Add(SelectedSoftver);

            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridSoftver.IsEnabled = false;

            Softver.sacuvajSoftver(Softveri.ToList());

            var item = dgrSoftver.Items[Softveri.Count - 1];
            dgrSoftver.SelectedItem = item;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajSoftver.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void SacuvajIzmjenu_Click(object sender, RoutedEventArgs e)
        {
            Softveri[indexSelektovanog] = SelectedSoftver;
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridSoftver.IsEnabled = false;

            Softver.sacuvajSoftver(Softveri.ToList());
            var item = dgrSoftver.Items[indexSelektovanog];
            dgrSoftver.SelectedItem = item;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

        private void IzmjenaOdustani_Click(object sender, RoutedEventArgs e)
        {
            SelectedSoftver = Softveri[indexSelektovanog];
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridSoftver.IsEnabled = false;

            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            if (Softveri.Count > 0)
            {
                SelectedSoftver = Softveri[0];
                var item = dgrSoftver.Items[0];
                dgrSoftver.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedSoftver = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }
            RezimPregled = true;
            gridSoftver.IsEnabled = false;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajSoftver.Visibility = Visibility.Hidden;

        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            Softveri.Remove(SelectedSoftver);
            if (Softveri.Count > 0)
            {
                SelectedSoftver = Softveri[0];
                var item = dgrSoftver.Items[0];
                dgrSoftver.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedSoftver = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }
            Softver.sacuvajSoftver(Softveri.ToList());
        }
    }
}
