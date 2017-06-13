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

        public SmjeroviPage(string v)
        {


            InitializeComponent();
            this.DataContext = this;

            List<Smjer> u = new List<Smjer>();
            u.Add(new Smjer("s1", "naziv", "opis", "12/02/1995"));


            Smjerovi = new ObservableCollection<Smjer>(u);

            DodajButton.IsEnabled = true;
            if (Smjerovi.Count > 0)
            {
                SelectedSmjer = Smjerovi[0];

                EnableIzbrisi = true;
                EnableIzmijeni = true;
            }
            else
            {
                EnableIzbrisi = false;
                EnableIzmijeni = false;
            }

            RezimPregled = true;
            gridSmjer.IsEnabled = false;
            Odustani.Visibility = Visibility.Hidden;
            SacuvajIzmjenu.Visibility = Visibility.Hidden;
            SacuvajSmjer.Visibility = Visibility.Hidden;
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
                    gridSmjer.IsEnabled = true;
                    DodajButton.IsEnabled = false;
                    Odustani.Visibility = Visibility.Visible;
                    SacuvajSmjer.Visibility = Visibility.Visible;
                    SelectedSmjer = new Smjer();

                });
                EnableIzmijeni = false;
                EnableIzbrisi = false;
                RezimPregled = false;


                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.Background = Brushes.Red;
                });
                SelectedSmjer.Id = "S";
                Thread.Sleep(300);
                SelectedSmjer.Id = "S1";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    idBox.Background = Brushes.White;
                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    nazivBox.Background = Brushes.Red;
                });

                Thread.Sleep(1000);
                SelectedSmjer.Naziv = "N";
                Thread.Sleep(300);
                SelectedSmjer.Naziv = "N1";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    nazivBox.Background = Brushes.White;
                });

                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    opisBox.Background = Brushes.Red;
                });
                SelectedSmjer.Opis = "O";
                Thread.Sleep(300);
                SelectedSmjer.Opis = "Op";
                Thread.Sleep(300);
                SelectedSmjer.Opis = "Opi";
                Thread.Sleep(300);
                SelectedSmjer.Opis = "Opis";
                Thread.Sleep(500);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    nazivBox.Background = Brushes.White;
                });
                Thread.Sleep(200);

                Thread.Sleep(1000);



                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    dateBox.IsDropDownOpen = true;
                });
                Thread.Sleep(1000);
                SelectedSmjer.DatumUvodjenja = "12/02/1995";
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    dateBox.IsDropDownOpen = false;
                });
                

                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajSmjer.Background = Brushes.Red;

                });
                Thread.Sleep(1000);


                

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajSmjer.Background = old;
                });
                Thread.Sleep(500);

                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    Smjerovi.Add(SelectedSmjer);
                });
                RezimPregled = true;
                EnableIzbrisi = true;
                EnableIzmijeni = true;
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    SacuvajSmjer.Visibility = Visibility.Hidden;
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
                    gridSmjer.IsEnabled = true;
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
                SelectedSmjer.Opis = "d";
                Thread.Sleep(300);
                SelectedSmjer.Opis = "dr";
                Thread.Sleep(300);
                SelectedSmjer.Opis = "dru";
                Thread.Sleep(300);
                SelectedSmjer.Opis = "drug";
                Thread.Sleep(300);
                SelectedSmjer.Opis = "drugi";
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
                    SacuvajSmjer.Visibility = Visibility.Hidden;
                    Odustani.Visibility = Visibility.Hidden;
                    SacuvajIzmjenu.Visibility = Visibility.Hidden;
                    IzmjenaOdustani.Visibility = Visibility.Hidden;
                    DodajButton.IsEnabled = true;

                });
                Thread.Sleep(2000);

                //obrisi
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    ObrisiButton.Background = Brushes.Red;

                });
                Thread.Sleep(1000);
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    ObrisiButton.Background = old;

                });


                Thread.Sleep(1000);

                App.Current.Dispatcher.Invoke((Action)delegate
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
                    RezimPregled = true;
                });

                Thread.Sleep(2000);
            }
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
        private string v;
        public Thread demoThread;

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
            List<Predmet> predmeti = PredmetiPage.getInstance().Predmeti.ToList();
            Predmet pronadjen = predmeti.Find(p => p.Smjer.Equals(SelectedSmjer));
            if(pronadjen != null)
            {
                MessageBox.Show("Nemoguce je obrisati smjer dok postoje predmeti koji mu pripadaju!");
                return;
            }
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
