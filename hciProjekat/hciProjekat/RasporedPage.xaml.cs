﻿using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RasporedPage.xaml
    /// </summary>
    public partial class RasporedPage : Page
    {
        Point startPoint = new Point();
        Raspored raspored = new Raspored();
        Termin termin = new Termin();
        Ucionica ucionica = new Ucionica();
        Predmet odabranPredmet = new Predmet();
        List<UcionicaRaspored> ucionicaRaspored = new List<UcionicaRaspored>();
        ListView listView_pomocni = new ListView();
        Predmet predmet_pomocni = new Predmet();

        Ucionica selected_ucionica = new Ucionica();

        private bool from_table = false;
        private int cell_row= 0;
        private int cell_column = 0;

        private RasporedPage()
        {
            InitializeComponent();
            this.DataContext = this;

            Ucionice = UcionicePage.getInstance().Ucionice;
            List<Predmet> listaPredmeta = new List<Predmet>();
            Termini = new List<List<ObservableCollection<Predmet>>>();

            foreach (Ucionica u in Ucionice) {
                ucionicaRaspored.Add(new UcionicaRaspored { Ucionica = u});
            }

            Predmeti = PredmetiPage.getInstance().Predmeti;

            List<Termin> termini = new List<Termin>();
            Termini1 = Termin.ucitajTermine();
            foreach (Termin t in Termini1) {
                termini.Add(new Termin { VremeTermina = t.VremeTermina });
            }
            Termini2 = new ObservableCollection<Termin>(termini);

            Termini3 = new List<List<ObservableCollection<Predmet>>>(Termini);


            for (int j = 0; j < 7; j++)
            {
                ColumnDefinition column = new ColumnDefinition();
                glavniGrid.ColumnDefinitions.Add(column);
            }

            for (int i = 0; i < 61; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    RowDefinition row = new RowDefinition();
                    glavniGrid.RowDefinitions.Add(row);
                    
                }
            }

            for (int j = 1; j < 61; j++)
            {
                DataGridCell cell = new DataGridCell();
                cell.Content = Termini1[j].VremeTermina;
                cell.Foreground = Brushes.White;
                Grid.SetRow(cell, j);
                Grid.SetColumn(cell, 0);
                cell.Width = 50;
                cell.Height = 25;
                glavniGrid.Children.Add(cell);
            }
        }

        private static RasporedPage instance;

        public static RasporedPage getInstance()
        {
            if (instance == null)
            {
                instance = new RasporedPage();
            }
            return instance;
        }


        public List<List<ObservableCollection<Predmet>>> Termini { get; private set; }
        public List<List<ObservableCollection<Predmet>>> Termini3 { get; private set; }

        public ObservableCollection<Termin> Termini1
        {
            get;
            set;
        }
        public ObservableCollection<Termin> Termini2
        {
            get;
            set;
        }

        public ObservableCollection<Termin> BrojTermina
        {
            get;
            set;
        }
        public ObservableCollection<Termin> BrojTermina2
        {
            get;
            set;
        }


        public ObservableCollection<Ucionica> Ucionice
        {
            get;
            set;
        }

        public ObservableCollection<Ucionica> Ucionice1
        {
            get;
            set;
        }

        public ObservableCollection<Predmet> Predmeti {
            get;
            set;
        }

        public ObservableCollection<Predmet> Predmeti1
        {
            get;
            set;
        }

        private int broj = 0;
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            broj++;
            startPoint = e.GetPosition(null);
            ListView listView = sender as ListView;
            try
            {
               
                predmet_pomocni = (Predmet)listView.SelectedItem;
            }
            catch {
                //
            }
            //minimalnu duzinu termina a ona je u predmetu*45
            cell_row = Grid.GetRow(listView);
            cell_column = Grid.GetColumn(listView);
            from_table = true;
        }

        private void ListView_PreviewMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            from_table = false;
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                if (listViewItem == null) {
                    return;
                }

                // Find the data behind the ListViewItem
                try
                {
                    Predmet p = (Predmet)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", p);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
                catch {
                    return;
                }


          
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                ListView listView = sender as ListView;
                int row = Grid.GetRow(listView);
                int column = Grid.GetColumn(listView);
                Predmet t = e.Data.GetData("myFormat") as Predmet;

                UcionicaRaspored ucionica_rasp= ucionicaRaspored.Find(s => s.Ucionica.Id.Equals(ucionica.Id));
                if (!from_table) {

                    for (int i = row; i < row + odabranPredmet.MinDuzinaTermina * 3; i++) {
                        if (ucionica_rasp.OdrzavaniPredmeti[i][column].Count() != 0)
                        {
                            MessageBox.Show("Nedovoljni termina ili je tremin popunjen");
                            return;
                        }                       
                    }
                }

                if (from_table)
                {
                        for (int i = row; i < row + odabranPredmet.MinDuzinaTermina * 3; i++)
                        {

                            if (ucionica_rasp.OdrzavaniPredmeti[i][column].Count != 0)
                            {
                            if (!ucionica_rasp.OdrzavaniPredmeti[i][column].ElementAt(0).Equals(null)) {
                                if (ucionica_rasp.OdrzavaniPredmeti[i][column].ElementAt(0).Equals(ucionica_rasp.OdrzavaniPredmeti[cell_row][cell_column].ElementAt(0)))
                                {
                                    break;
                                    
                                }
                                else {
                                    MessageBox.Show("Nedovoljni termina ili je tremin popunjen");
                                    return;
                                }
                            }

                                
                            }
                        }
                    if (ucionica_rasp.OdrzavaniPredmeti[cell_row][cell_column].ElementAt(0) == null) {
                        return;
                    }
                    Predmet pomocni_pr = ucionica_rasp.OdrzavaniPredmeti[cell_row][cell_column].ElementAt(0);
                    if (pomocni_pr.PomocniBroj.Equals(null)) {
                        return;
                    }
                    int razlika = pomocni_pr.PomocniBroj;
                    for (int i = cell_row; i < cell_row + odabranPredmet.MinDuzinaTermina * 3; i++) {

                            ucionica_rasp.OdrzavaniPredmeti[razlika][cell_column].RemoveAt(0);
                            razlika++;
                    }
                }

                if (row + 3 * t.MinDuzinaTermina>61) {
                    MessageBox.Show("Prekoracili ste termin.");
                    return;
                }
               
                if (!from_table) {
                    odabranPredmet.PomocniBrojTermina++;
                    if (odabranPredmet.PomocniBrojTermina == odabranPredmet.BrojTermina)
                    {
                        Predmeti1.Clear();
                        prikazTermina.ItemsSource = Predmeti1;
                        prikazTermina.Visibility = Visibility.Visible;
                    }
                }
                else if (odabranPredmet.PomocniBrojTermina == odabranPredmet.BrojTermina) {
                    Predmeti1.Clear();
                    prikazTermina.ItemsSource = Predmeti1;
                    prikazTermina.Visibility = Visibility.Visible;
                }


                var end = 0;
                Predmet p = new Predmet(t);
                for (int i = 0; i < t.MinDuzinaTermina; i++)
                {
                    // t.PomocniBroj = row+end;
                    ucionica_rasp.OdrzavaniPredmeti[row + end][column].Add(p);
                    ucionica_rasp.OdrzavaniPredmeti[row + end][column].ElementAt(0).PomocniBroj = row;
                    // t.PomocniBroj = row + end+1;
                    ucionica_rasp.OdrzavaniPredmeti[row + 1 + end][column].Add(p);

                    ucionica_rasp.OdrzavaniPredmeti[row + end + 1][column].ElementAt(0).PomocniBroj = row;
                    //t.PomocniBroj = row + end+2;
                    ucionica_rasp.OdrzavaniPredmeti[row + 2 + end][column].Add(p);

                    ucionica_rasp.OdrzavaniPredmeti[row + end + 2][column].ElementAt(0).PomocniBroj = row;
                    var j = i + 1;
                    end = 3 * j;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (odabranP.SelectedItem == null)
            {
                MessageBox.Show("Potrebno je odabrati predmet.");
                return;
            }
            odabranPredmet = (Predmet)odabranP.SelectedItem;
            List<Ucionica> ucioniceTemp = new List<Ucionica>();
            foreach (Ucionica u in Ucionice) {
                if ((odabranPredmet.NeophodanOS == u.InstaliranOS) || (odabranPredmet.NeophodanOS == OS.svejedno) || (u.InstaliranOS == OS.svejedno))
                {
                    List<Softver> softveri = u.InstaliraniSoftver;
                    foreach (Softver s in softveri)
                    {
                        if (odabranPredmet.NeophodanSoftver.Equals(s))
                        {
                            ucioniceTemp.Add(u);
                        }
                    }
                }
            }
            if (odabranPredmet.PomocniBrojTermina == odabranPredmet.BrojTermina)
            {
                MessageBox.Show("Ne postoji vise potrebnih termina za odabrani predmet!");
                return;
            }
            Ucionice1 = new ObservableCollection<Ucionica>(ucioniceTemp);
            prikazUcionica.ItemsSource = Ucionice1;
            Label_odabir_ucionice.Visibility = Visibility.Visible;
            prikazUcionica.Visibility = Visibility.Visible;
            confirm_ucionice.Visibility = Visibility.Visible;
            confirm_ucionice_moj.Visibility = Visibility.Hidden;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (prikazUcionica.SelectedItem == null)
            {
                MessageBox.Show("Potrebno je odabrati ucionicu.");
                return;
            }
            if (odabranPredmet.PomocniBrojTermina == odabranPredmet.BrojTermina)
            {
                MessageBox.Show("Ne postoji vise potrebnih termina za odabrani predmet!");
                return;
            }

            ucionica=(Ucionica) prikazUcionica.SelectedItem;
            Inicijalizuj_Termine(ucionica);
            List<Predmet> predmeti = new List<Predmet>();
            predmeti.Add(odabranPredmet);
            Predmeti1 = new ObservableCollection<Predmet>(predmeti);
            prikazTermina.ItemsSource = Predmeti1;
            prikazTermina.Visibility = Visibility.Visible;
            Label_odabir_termina.Visibility = Visibility.Visible;
            glavniGrid.Visibility = Visibility.Visible;
            skroler.Visibility = Visibility.Visible;
            glavniGrid.IsEnabled = true;
            Obrisi.Visibility = Visibility.Visible;
            button_save.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<Predmet> predmeti = new List<Predmet>();
            predmeti.Add(odabranPredmet);
            Predmeti1 = new ObservableCollection<Predmet>(predmeti);
            prikazTermina.ItemsSource = Predmeti1;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                UcionicaRaspored ucionica_rasp = ucionicaRaspored.Find(s => s.Ucionica.Id.Equals(ucionica.Id));
                Predmet pomocni_pr = ucionica_rasp.OdrzavaniPredmeti[cell_row][cell_column].ElementAt(0);
                if (pomocni_pr.PomocniBroj.Equals(null))
                {
                    return;
                }
                int razlika = pomocni_pr.PomocniBroj;
                for (int i = cell_row; i < cell_row + odabranPredmet.MinDuzinaTermina * 3; i++)
                {
                    ucionica_rasp.OdrzavaniPredmeti[razlika][cell_column].RemoveAt(0);
                    razlika++;
                }
                if (from_table)
                {
                    odabranPredmet.PomocniBrojTermina--;
                }

                if (odabranPredmet.PomocniBrojTermina!=odabranPredmet.BrojTermina) {
                    if (Predmeti1.Count() == 0) {
                        Predmeti1.Add(odabranPredmet);
                        prikazTermina.ItemsSource = Predmeti1;
                        prikazTermina.Visibility = Visibility.Visible;
                    }
                }
 

            }
            catch { MessageBox.Show("Niste odabrali termin"); return; }
        }

        private void Inicijalizuj_Termine(Ucionica u) {

            ////

            string[] niz = { "", "Ponedeljak", "Utorak", "Sreda", "Cetrvtak", "Petak", "Subota" };

            for (int i = 1; i < 7; i++)
            {
                DataGridCell cell = new DataGridCell();
                cell.Content = niz[i];
                cell.Foreground = Brushes.White;
                cell.FontWeight = FontWeights.Bold;
                Grid.SetRow(cell, 0);
                Grid.SetColumn(cell, i);

                glavniGrid.Children.Add(cell);
            }


            ////
            UcionicaRaspored ucionica_rasp = ucionicaRaspored.Find(s => s.Ucionica.Id.Equals(u.Id));

            for (int i = 1; i < 61; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    ListView list = new ListView();
                    list.ItemsSource = ucionica_rasp.OdrzavaniPredmeti[i][j];
                    DataTemplate template = new DataTemplate();

                    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(ListView));
                    template.VisualTree = factory;
                    FrameworkElementFactory imgFactory = new FrameworkElementFactory(typeof(TextBlock));

                    Binding newBinding = new Binding("Naziv");
                    imgFactory.SetBinding(TextBlock.TextProperty, newBinding);

                    factory.AppendChild(imgFactory);

                    list.ItemTemplate = template;
                    list.Name = "ja";
                    list.Background = Brushes.White;
                    list.AllowDrop = true;
                    list.DragEnter += ListView_DragEnter;
                    list.Drop += ListView_Drop;
                    list.MouseMove += ListView_MouseMove;
                    list.PreviewMouseLeftButtonDown += ListView_PreviewMouseLeftButtonDown;
                    Grid.SetRow(list, i);
                    Grid.SetColumn(list, j);
                    glavniGrid.Children.Add(list);
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog openFileDialog = new Microsoft.Win32.SaveFileDialog();
           
            if (openFileDialog.ShowDialog() == true)
            {

            }
            String filename = openFileDialog.FileName;
            if(!filename.Equals(""))
            {
                
                using (Stream stream = File.Open(filename, FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, ucionicaRaspored);
                }
            }
            Predmet.sacuvajPredmete(PredmetiPage.getInstance().Predmeti.ToList());
        }

        public bool Ucitavanje_Metoda()
        {
            bool uzeo = false;
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {

            }
            String filename = openFileDialog.FileName;
            if (!filename.Equals(""))
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    ucionicaRaspored =  (List<UcionicaRaspored>) binaryFormatter.Deserialize(stream);
                }
                uzeo = true;
            }
            

            List<Ucionica> sveUcionice = UcionicePage.getInstance().Ucionice.ToList();
            List<Predmet> sviPredmeti = PredmetiPage.getInstance().Predmeti.ToList();
            return uzeo;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {//treba srediti ucionicu

            prikazUcionica.Visibility = Visibility.Hidden;
            prikazUcionica_Moj.Visibility = Visibility.Visible;
            prikazTermina.Visibility = Visibility.Hidden;
            button_save.Visibility = Visibility.Hidden;
            Label_odabir_termina.Visibility = Visibility.Hidden;
            Obrisi.Visibility = Visibility.Hidden;
            confirm_ucionice_moj.Visibility = Visibility.Visible;
            confirm_ucionice.Visibility = Visibility.Hidden;

            skroler.Visibility = Visibility.Visible;
            glavniGrid.Visibility = Visibility.Visible;

            ucionica = (Ucionica)prikazUcionica_Moj.SelectedItem;
            Inicijalizuj_Termine(ucionica);

            confirm_ucionice_moj.Visibility = Visibility.Visible;

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (prikazUcionica_Moj.SelectedItem == null)
            {
                MessageBox.Show("Potrebno je odabrati ucionicu.");
                return;
            }

            skroler.Visibility = Visibility.Visible;
            glavniGrid.Visibility = Visibility.Visible;

            ucionica = (Ucionica)prikazUcionica_Moj.SelectedItem;
            Inicijalizuj_Termine(ucionica);

            confirm_ucionice_moj.Visibility = Visibility.Visible;


        }

        public void Novi_Metoda() {
            Ucionice =UcionicePage.getInstance().Ucionice;
            ucionicaRaspored.Clear();
            foreach (Ucionica u in Ucionice)
            {
                ucionicaRaspored.Add(new UcionicaRaspored { Ucionica = u });
            }
            
        }
    }


}
