using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

        public SoftverPage(string v)
        {
            InitializeComponent();
            this.DataContext = this;

            List<Softver> u = new List<Softver>();
            u.Add(new Softver("oznaka","naziv", "proizvodjac","www.sajt.com", 2014,10000, "opis", OS.svejedno));


            Softveri = new ObservableCollection<Softver>(u);

            DodajButton.IsEnabled = true;
            if (Softveri.Count > 0)
            {
                SelectedSoftver = Softveri[0];

                EnableIzbrisi = true;
                EnableIzmijeni = true;
            }
            else
            {
                EnableIzbrisi = false;
                EnableIzmijeni = false;
            }

            RezimPregled = true;
            gridSoftver.IsEnabled = false;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajSoftver.Visibility = Visibility.Hidden;
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
                    old = (LinearGradientBrush)DodajButton.Background;
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
                    gridSoftver.IsEnabled = true;
                    DodajButton.IsEnabled = false;
                    Odustani.Visibility = Visibility.Visible;
                    SacuvajSoftver.Visibility = Visibility.Visible;
                    SelectedSoftver = new Softver();

                });
                EnableIzmijeni = false;
                EnableIzbrisi = false;
                RezimPregled = false;


                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.Background = Brushes.Red;
                });
                SelectedSoftver.Id = "S";
                Thread.Sleep(300);
                SelectedSoftver.Id = "S1";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.Background = Brushes.White;
                });
                Thread.Sleep(1000);

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    nazivBox.Background = Brushes.Red;
                });
                SelectedSoftver.Naziv = "n";
                Thread.Sleep(300);
                SelectedSoftver.Naziv = "n1";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    nazivBox.Background = Brushes.White;
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    proizvodjacBox.Background = Brushes.Red;
                });
                SelectedSoftver.Proizvodjac = "p";
                Thread.Sleep(300);
                SelectedSoftver.Proizvodjac = "p1";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    proizvodjacBox.Background = Brushes.White;
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    sajtBox.Background = Brushes.Red;
                });
                SelectedSoftver.Sajt = "s";
                Thread.Sleep(300);
                SelectedSoftver.Sajt = "sa";
                Thread.Sleep(300);
                SelectedSoftver.Sajt = "saj";
                Thread.Sleep(300);
                SelectedSoftver.Sajt = "sajt";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    sajtBox.Background = Brushes.White;
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    godinaBox.Background = Brushes.Red;
                });
                SelectedSoftver.GodinaIzdavanja = 2;
                Thread.Sleep(300);
                SelectedSoftver.GodinaIzdavanja = 20;
                Thread.Sleep(300);
                SelectedSoftver.GodinaIzdavanja = 200;
                Thread.Sleep(300);
                SelectedSoftver.GodinaIzdavanja = 2009;
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    godinaBox.Background = Brushes.White;
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    cijenaBox.Background = Brushes.Red;
                });
                SelectedSoftver.Cijena = 2;
                Thread.Sleep(300);
                SelectedSoftver.Cijena = 20;
                Thread.Sleep(300);
                SelectedSoftver.Cijena = 200;
                Thread.Sleep(300);
                SelectedSoftver.Cijena = 2000;
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    cijenaBox.Background = Brushes.White;
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    osBox.IsDropDownOpen = true;
                });

                Thread.Sleep(1000);
                selectedSoftver.OperativniSistem = OS.linux;
                Thread.Sleep(500);

                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    osBox.IsDropDownOpen = false;
                });

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.Background = Brushes.Red;
                });
                SelectedSoftver.Opis = "o";
                Thread.Sleep(300);
                SelectedSoftver.Opis = "op";
                Thread.Sleep(300);
                SelectedSoftver.Opis = "opi";
                Thread.Sleep(300);
                SelectedSoftver.Opis = "opis";
                Thread.Sleep(300);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.Background = Brushes.White;
                });
                Thread.Sleep(1000);


                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajSoftver.Background = Brushes.Red;

                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajSoftver.Background = old;
                });
                Thread.Sleep(500);

                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    Softveri.Add(SelectedSoftver);
                });
                RezimPregled = true;
                EnableIzbrisi = true;
                EnableIzmijeni = true;
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajSoftver.Visibility = Visibility.Hidden;
                    Odustani.Visibility = Visibility.Hidden;
                    SacuvajIzmjenu.Visibility = Visibility.Hidden;
                    IzmjenaOdustani.Visibility = Visibility.Hidden;
                    DodajButton.IsEnabled = true;

                });
                Thread.Sleep(2000);

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzmijeniButton.Background = Brushes.Red;

                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzmijeniButton.Background = old;

                });

                Thread.Sleep(200);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    gridSoftver.IsEnabled = true;
                    DodajButton.IsEnabled = false;
                    IzmjenaOdustani.Visibility = Visibility.Visible;
                    SacuvajIzmjenu.Visibility = Visibility.Visible;


                });
                EnableIzmijeni = false;
                EnableIzbrisi = false;
                RezimPregled = false;


                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.Background = Brushes.Red;
                });
                SelectedSoftver.Opis = "d";
                Thread.Sleep(300);
                SelectedSoftver.Opis = "dr";
                Thread.Sleep(300);
                SelectedSoftver.Opis = "dru";
                Thread.Sleep(300);
                SelectedSoftver.Opis = "drug";
                Thread.Sleep(300);
                SelectedSoftver.Opis = "drugi";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.Background = Brushes.White;
                });
                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajIzmjenu.Background = Brushes.Red;


                });
                Thread.Sleep(600);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajIzmjenu.Background = old;
                });
                Thread.Sleep(500);


                RezimPregled = true;
                EnableIzbrisi = true;
                EnableIzmijeni = true;
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajSoftver.Visibility = Visibility.Hidden;
                    Odustani.Visibility = Visibility.Hidden;
                    SacuvajIzmjenu.Visibility = Visibility.Hidden;
                    IzmjenaOdustani.Visibility = Visibility.Hidden;
                    DodajButton.IsEnabled = true;

                });
                Thread.Sleep(2000);

                //obrisi
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzbrisiButton.Background = Brushes.Red;

                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzbrisiButton.Background = old;

                });


                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate
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
                    RezimPregled = true;
                });

                Thread.Sleep(2000);
            }
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
        
        public Thread demoThread;

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
            List<Predmet> predmeti = PredmetiPage.getInstance().Predmeti.ToList();
            Predmet pronadjen = predmeti.Find(s => s.NeophodanSoftver.Equals(SelectedSoftver));
            if(pronadjen != null)
            {
                MessageBox.Show("Nemoguce je obrisati softver dok postoje predmeti kojima je neophodan");
                return;
            }

            List<Ucionica> ucionice = UcionicePage.getInstance().Ucionice.ToList();
            Ucionica pronadjena = ucionice.Find(u => u.InstaliraniSoftver.Contains(SelectedSoftver));
            if (pronadjena != null)
            {
                MessageBox.Show("Nemoguce je obrisati softver dok postoje ucionice u kojima instaliran");
                return;
            }
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
