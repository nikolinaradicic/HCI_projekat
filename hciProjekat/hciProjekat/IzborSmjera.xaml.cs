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
using System.Windows.Shapes;

namespace hciProjekat
{
    /// <summary>
    /// Interaction logic for IzborSmjera.xaml
    /// </summary>
    public partial class IzborSmjera : Window, INotifyPropertyChanged
    {
        
        public IzborSmjera(ObservableCollection<Smjer> smjerovi, Smjer smjer)
        {
            Smjerovi = smjerovi;
            this.DataContext = this;
            this.SelectedSmjer = smjer;
            InitializeComponent();
        }

        public IzborSmjera(string v)
        {
            Smjerovi = new ObservableCollection<Smjer>();
            Smjer s1 = new Smjer("s1", "n1", "opis1", "12/02/1995");
            Smjer s2 = new Smjer("s2", "naziv2", "opis2","12/07/2001");
            
            Smjerovi.Add(s1);
            Smjerovi.Add(s2);
            this.DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Smjer selectedSmjer;
        private string v;

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

        public ObservableCollection<Smjer> Smjerovi
        {
            get;
            set;
        }

        private void Izaberi_Click(object sender, RoutedEventArgs e)
        {
            PredmetiPage.getInstance().SelectedPredmet.Smjer = SelectedSmjer;
            this.Close();
        }

    }
}
