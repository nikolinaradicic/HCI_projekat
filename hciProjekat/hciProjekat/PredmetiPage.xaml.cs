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

        public PredmetiPage(string v)
        {
            InitializeComponent();
            this.DataContext = this;

            List<Predmet> u = new List<Predmet>();
            u.Add(new Predmet("p1","naziv", "",32,3,12,true, true,true,new Smjer(),OS.widows,new Softver(),0));


            Predmeti = new ObservableCollection<Predmet>(u);

            if (Predmeti.Count > 0)
            {
                SelectedPredmet = Predmeti[0];

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
            gridPredmeti.IsEnabled = false;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajPredmet.Visibility = Visibility.Hidden;
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

                IzborSmjera izborSmjera = null;
                IzborSoftvera izborSoftvera = null;
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
                    gridPredmeti.IsEnabled = true;
                    DodajButton.IsEnabled = false;
                    Odustani.Visibility = Visibility.Visible;
                    SacuvajPredmet.Visibility = Visibility.Visible;
                    SelectedPredmet = new Predmet();

                });
                EnableIzmijeni = false;
                EnableIzbrisi = false;
                RezimPregled = false;


                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.Background = Brushes.Red;
                });
                SelectedPredmet.Id = "U";
                Thread.Sleep(300);
                SelectedPredmet.Id = "U1";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.Background = Brushes.White;
                });
                Thread.Sleep(200);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.Background = Brushes.Red;
                });
                SelectedPredmet.Opis = "o";
                Thread.Sleep(300);
                SelectedPredmet.Opis = "op";
                Thread.Sleep(300);
                SelectedPredmet.Opis = "opi";
                Thread.Sleep(300);
                SelectedPredmet.Opis = "opis";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.Background = Brushes.White;
                });
                Thread.Sleep(200);


                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    nazivBox.Background = Brushes.Red;
                });
                SelectedPredmet.Naziv = "n";
                Thread.Sleep(300);
                SelectedPredmet.Naziv = "n1";
                Thread.Sleep(300);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    nazivBox.Background = Brushes.White;
                });
                Thread.Sleep(200);

                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    grupaBox.Background = Brushes.Red;
                });
                Thread.Sleep(300);
                selectedPredmet.VelicinaGrupe = 2;
                Thread.Sleep(300);
                SelectedPredmet.VelicinaGrupe = 25;
                Thread.Sleep(300);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    grupaBox.Background = Brushes.White;
                });
                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    duzinaTerminaBox.Background = Brushes.Red;
                });
                Thread.Sleep(300);
                selectedPredmet.MinDuzinaTermina = 2;
                Thread.Sleep(300);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    duzinaTerminaBox.Background = Brushes.White;
                });
                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    terminiBox.Background = Brushes.Red;
                });
                Thread.Sleep(300);
                selectedPredmet.BrojTermina = 1;
                Thread.Sleep(300);
                SelectedPredmet.BrojTermina = 15;
                Thread.Sleep(300);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    terminiBox.Background = Brushes.White;
                });
                Thread.Sleep(1000);
                
                App.Current.Dispatcher.Invoke((Action)delegate {
                    projektorBox.Background = Brushes.Red;
                });

                Thread.Sleep(500);
                SelectedPredmet.Projektor = true;
                App.Current.Dispatcher.Invoke((Action)delegate {
                    projektorBox.Background = Brushes.White;
                });
                Thread.Sleep(500);
                
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    osBox.IsDropDownOpen = true;
                });


                Thread.Sleep(300);
                SelectedPredmet.NeophodanOS = OS.svejedno;
                Thread.Sleep(300);

                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    osBox.IsDropDownOpen = false;
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzaberiButton.Background = Brushes.Red;
                });


                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    izborSmjera = new IzborSmjera("demo");
                    izborSmjera.Show();
                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    izborSmjera.SelectedSmjer = izborSmjera.Smjerovi[0];
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    izborSmjera.Izaberi.Background = Brushes.Red;

                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    izborSmjera.Close();
                    SelectedPredmet.Smjer = izborSmjera.SelectedSmjer;
                    IzaberiButton.Background = Brushes.Gray;
                });


                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzaberiSoftver.Background = Brushes.Red;
                });


                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    izborSoftvera = new IzborSoftvera("demo");
                    izborSoftvera.Show();
                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    izborSoftvera.SelectedSoftver = izborSoftvera.Softveri[0];
                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    izborSoftvera.Izaberi.Background = Brushes.Red;

                });

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SelectedPredmet.NeophodanSoftver = izborSoftvera.SelectedSoftver;
                    izborSoftvera.Close();

                    IzaberiSoftver.Background = Brushes.Gray;
                });



                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajPredmet.Background = Brushes.Red;

                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajPredmet.Background = old;
                });
                Thread.Sleep(500);

                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    Predmeti.Add(SelectedPredmet);
                    IzaberiButton.Background = Brushes.Gray;
                    RezimPregled = true;
                });
                RezimPregled = true;
                EnableIzbrisi = true;
                EnableIzmijeni = true;
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajPredmet.Visibility = Visibility.Hidden;
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
                    gridPredmeti.IsEnabled = true;
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
                SelectedPredmet.Opis = "d";
                Thread.Sleep(300);
                SelectedPredmet.Opis = "dr";
                Thread.Sleep(300);
                SelectedPredmet.Opis = "dru";
                Thread.Sleep(300);
                SelectedPredmet.Opis = "drug";
                Thread.Sleep(300);
                SelectedPredmet.Opis = "drugi";
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
                    SacuvajPredmet.Visibility = Visibility.Hidden;
                    Odustani.Visibility = Visibility.Hidden;
                    SacuvajIzmjenu.Visibility = Visibility.Hidden;
                    IzmjenaOdustani.Visibility = Visibility.Hidden;
                    DodajButton.IsEnabled = true;

                });
                Thread.Sleep(2000);

                //obrisi
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzbisiButton.Background = Brushes.Red;

                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    IzbisiButton.Background = old;

                });


                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate
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
                    RezimPregled = true;
                });

                Thread.Sleep(2000);
            }
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
        private string v;
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
                selectedPredmet.NeophodanOS, selectedPredmet.NeophodanSoftver,selectedPredmet.PomocniBrojTermina);

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


        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                str = "prikaz_predmeta";
                HelpProvider.ShowHelp(str, this);
            }
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

        private void IzaberiButton_Click(object sender, RoutedEventArgs e)
        {
            IzborSmjera izborSmjera = new IzborSmjera(SmjeroviPage.getInstance().Smjerovi, SelectedPredmet.Smjer);
            izborSmjera.Show();
        }

        private void IzaberiSoftver_Click(object sender, RoutedEventArgs e)
        {
            IzborSoftvera izborSoftvera = new IzborSoftvera(SoftverPage.getInstance().Softveri, SelectedPredmet.NeophodanSoftver);
            izborSoftvera.Show();
        }
    }
}
