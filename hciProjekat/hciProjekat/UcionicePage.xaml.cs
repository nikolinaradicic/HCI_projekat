using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Thread demoThread;
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

        public UcionicePage(string v)
        {
            InitializeComponent();
            this.DataContext = this;
           
            List<Ucionica> u = new List<Ucionica>();
            u.Add(new Ucionica("Oznaka", "opis", 23,true,true,true,new List<Softver>(), OS.widows));


            Ucionice = new ObservableCollection<Ucionica>(u);
            
            if (Ucionice.Count > 0)
            {
                SelectedUcionica = Ucionice[0];

                EnableIzbrisi = true;
                EnableIzmijeni = true;
                DodajButton.IsEnabled = true;
            }
            else
            {
                EnableIzbrisi = false;
                EnableIzmijeni = false;
            }

            RezimPregled = true;
            gridUcionice.IsEnabled = false;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajUcionicu.Visibility = Visibility.Hidden;
            IzmjenaOdustani.Visibility = Visibility.Hidden;
            
            demoThread = new Thread(new ThreadStart(pokaziDemo));
            demoThread.Start();
            
        }

        private void pokaziDemo()
        {
            while (true)
            {
                Thread.Sleep(2000);
                LinearGradientBrush old = new LinearGradientBrush();
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    old = (LinearGradientBrush) DodajButton.Background;
                    DodajButton.Background = Brushes.Red;

                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    DodajButton.Background = old;
                    
                });

                Thread.Sleep(200);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    gridUcionice.IsEnabled = true;

                    Odustani.Visibility = Visibility.Visible;
                    SacuvajUcionicu.Visibility = Visibility.Visible;
                    SelectedUcionica = new Ucionica();

                });
                EnableIzmijeni = false;
                EnableIzbrisi = false;
                RezimPregled = false;
                
                
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.BorderBrush = new SolidColorBrush(Colors.CadetBlue);
                });
                SelectedUcionica.Id = "U";
                Thread.Sleep(300);
                SelectedUcionica.Id = "U1";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.BorderBrush = new SolidColorBrush(Colors.Silver);
                });
                Thread.Sleep(200);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.BorderBrush = new SolidColorBrush(Colors.CadetBlue);
                });
                SelectedUcionica.Opis = "o";
                Thread.Sleep(300);
                SelectedUcionica.Opis = "op";
                Thread.Sleep(300);
                SelectedUcionica.Opis = "opi";
                Thread.Sleep(300);
                SelectedUcionica.Opis = "opis";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    opisBox.BorderBrush = new SolidColorBrush(Colors.Silver);
                });
                Thread.Sleep(200);
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    brojMjestaBox.BorderBrush = new SolidColorBrush(Colors.CadetBlue);
                });
                Thread.Sleep(300);
                SelectedUcionica.BrojMjesta = 1;
                Thread.Sleep(300);
                SelectedUcionica.BrojMjesta = 18;
                Thread.Sleep(300);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    brojMjestaBox.BorderBrush = new SolidColorBrush(Colors.Silver);
                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    projektorBox.BorderBrush = new SolidColorBrush(Colors.CadetBlue);
                });

                Thread.Sleep(500);
                SelectedUcionica.Projektor = true;
                App.Current.Dispatcher.Invoke((Action)delegate{
                    projektorBox.BorderBrush = new SolidColorBrush(Colors.Silver);
                });
                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajUcionicu.Background = Brushes.Red;


                });
                Thread.Sleep(600);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajUcionicu.Background = old;
                });
                Thread.Sleep(500);

                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    Ucionice.Add(SelectedUcionica);
                    RezimPregled = true;
                });

                EnableIzbrisi = true;
                EnableIzmijeni = true;
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajUcionicu.Visibility = Visibility.Hidden;
                    Odustani.Visibility = Visibility.Hidden;
                    SacuvajIzmjenu.Visibility = Visibility.Hidden;
                    IzmjenaOdustani.Visibility = Visibility.Hidden;

                });
                Thread.Sleep(2000);
            }
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
        private string v;

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
