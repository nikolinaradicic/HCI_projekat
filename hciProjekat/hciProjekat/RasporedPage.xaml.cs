using hciProjekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private RasporedPage()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Ucionica> listaUcionica = new List<Ucionica>();
            Ucionice = Ucionica.ucitajUcionice();
            foreach (Ucionica u in Ucionice)
            {
                listaUcionica.Add(new Ucionica { Id = u.Id, Opis = u.Opis });
                raspored.Termini[u.Id] = new List<Termin>();
            }


            List<Termin> termini = new List<Termin>();
            Termini1 = Termin.ucitajTermine();
            foreach (Termin t in Termini1) {
                termini.Add(new Termin { VremeTermina = t.VremeTermina });
            }

            //List<Termin> brojevi = new List<Termin>();
            //BrojTermina = Termin.ucitajVreme();
            //foreach (Termin t in BrojTermina) {
            //    brojevi.Add(new Termin { BrojTermina = t.BrojTermina });
            //}

            Ucionice1 = new ObservableCollection<Ucionica>(listaUcionica);
            Termini2 = new ObservableCollection<Termin>(termini);
            //BrojTermina2 = new ObservableCollection<Termin>(brojevi);

            Termini = new List<List<ObservableCollection<Predmet>>>();
            for (int i = 0; i < 61; i++)
            {
                List<ObservableCollection<Predmet>> temp = new List<ObservableCollection<Predmet>>();
                for (int j = 0; j < 7; j++) {
                    temp.Add(new ObservableCollection<Predmet>());
                }
                Termini.Add(temp);
            }

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

            for (int j = 1; j <36 ; j++)
            {
                DataGridCell cell = new DataGridCell();
                cell.Content = Termini1[j].VremeTermina;
                Grid.SetRow(cell, j);
                Grid.SetColumn(cell, 0);

                glavniGrid.Children.Add(cell);
            }

            string[] niz = {"","Ponedeljak","Utorak","Sreda","Cetrvtak","Petak","Subota"};

            for (int i = 1; i < 7; i++) {
                DataGridCell cell = new DataGridCell();
                cell.Content = niz[i];
                Grid.SetRow(cell, 0);
                Grid.SetColumn(cell, i);
                
                glavniGrid.Children.Add(cell);
            }

            for (int i = 1; i < 61; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    ListView list = new ListView();
                    list.ItemsSource = Termini[i][j];
                    Grid.SetRow(list, i);
                    Grid.SetColumn(list, j);
                    glavniGrid.Children.Add(list);
                }
            }

            //------

            //< DataGridCell
            //      Grid.Row = "1"
            //      Grid.Column = "0"
            //      BorderBrush = "Black"
            //      BorderThickness = "1" >
            //      07:00
            //  </ DataGridCell >

            //------


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



        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
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

                // Find the data behind the ListViewItem
                Termin t = (Termin)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", t);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
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
                Termin t = e.Data.GetData("myFormat") as Termin;
                //Predmeti1.Remove(student);
                raspored.Termini["1"].Add(t);
            }
        }

    }


}
