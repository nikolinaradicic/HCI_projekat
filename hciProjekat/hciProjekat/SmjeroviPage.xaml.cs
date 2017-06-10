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
    /// Interaction logic for SmjeroviPage.xaml
    /// </summary>
    public partial class SmjeroviPage : Page, INotifyPropertyChanged
    {
        private SmjeroviPage()
        {

            InitializeComponent();
            this.DataContext = this;
            Smjerovi = Smjer.ucitajSmjerove();
            if (Smjerovi.Count > 0)
            {
                SelectedSmjer = Smjerovi[0];
                EnableIzbrisi = true;
                EnableIzmijeni = true;
            }
            RezimPregled = true;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajSmjer.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

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
            get { return rezimPregled; }
            set
            {
                if (rezimPregled != value)
                {
                    rezimPregled = value;
                    OnPropertyChanged("RezimPregled");
                }
            }
        }
        private Smjer selectedSmjer;
        public Smjer SelectedSmjer
        {
            get
            {
                return selectedSmjer;
            }
            set
            {
                if (selectedSmjer != value)
                {
                    selectedSmjer = value;
                    OnPropertyChanged("SelectedSmjer");
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


        internal void dodajSmjer()
        {
            SelectedSmjer = new Smjer();
            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            Odustani.Visibility = Visibility.Visible;
            SacuvajSmjer.Visibility = Visibility.Visible;
            gridSmjer.IsEnabled = true;
        }
        
        

        internal void izmijeniSmjer()
        {

            RezimPregled = false;
            EnableIzmijeni = false;
            EnableIzbrisi = false;
            indexSelektovanog = Smjerovi.IndexOf(selectedSmjer);
            SelectedSmjer = new Smjer(selectedSmjer.Id, selectedSmjer.Naziv, selectedSmjer.Opis, selectedSmjer.DatumUvodjenja);

            gridSmjer.IsEnabled = true;
            SacuvajIzmjenu.Visibility = Visibility.Visible;
            IzmjenaOdustani.Visibility = Visibility.Visible;
        }
        
        private void SacuvajSmjer_Click(object sender, RoutedEventArgs e)
        {
            Smjerovi.Add(SelectedSmjer);
            
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridSmjer.IsEnabled = false;
            
            Smjer.sacuvajSmjerove(Smjerovi.ToList());
            
            var item = dgrSmjerovi.Items[Smjerovi.Count-1];
            dgrSmjerovi.SelectedItem = item;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajSmjer.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void SacuvajIzmjenu_Click(object sender, RoutedEventArgs e)
        {
            Smjerovi[indexSelektovanog] = SelectedSmjer;
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridSmjer.IsEnabled = false;
            
            Smjer.sacuvajSmjerove(Smjerovi.ToList());
            var item = dgrSmjerovi.Items[indexSelektovanog];
            dgrSmjerovi.SelectedItem = item;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
        }

        private void IzmjenaOdustani_Click(object sender, RoutedEventArgs e)
        {
            SelectedSmjer = Smjerovi[indexSelektovanog];
            RezimPregled = true;

            EnableIzmijeni = true;
            EnableIzbrisi = true;
            gridSmjer.IsEnabled = false;

            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            if (Smjerovi.Count > 0)
            {
                SelectedSmjer = Smjerovi[0];
                var item = dgrSmjerovi.Items[0];
                dgrSmjerovi.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedSmjer = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }
            RezimPregled = true;
            gridSmjer.IsEnabled = false;

            Odustani.Visibility = Visibility.Hidden;
            SacuvajSmjer.Visibility = Visibility.Hidden;

        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            Smjerovi.Remove(SelectedSmjer);
            if (Smjerovi.Count > 0)
            {
                SelectedSmjer = Smjerovi[0];
                var item = dgrSmjerovi.Items[0];
                dgrSmjerovi.SelectedItem = item;
                EnableIzmijeni = true;
                EnableIzbrisi = true;
            }
            else
            {
                SelectedSmjer = null;
                EnableIzmijeni = false;
                EnableIzbrisi = false;
            }

        }
    }
}
