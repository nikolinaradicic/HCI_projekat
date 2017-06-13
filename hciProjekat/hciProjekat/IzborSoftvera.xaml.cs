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
    /// Interaction logic for IzborSoftvera.xaml
    /// </summary>
    public partial class IzborSoftvera : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public IzborSoftvera(ObservableCollection<Softver> softveri, Softver neophodanSoftver)
        {
            this.SelectedSoftver = neophodanSoftver;
            this.Softveri = softveri;
            this.DataContext = this;
            InitializeComponent();
        }

        public IzborSoftvera(string v)
        {
            Softveri = new ObservableCollection<Softver>();
            Softver s1 = new Softver("softver1", "naziv1", "proizvodjac", "sajt", 2007, 20000, "", OS.svejedno);
            Softver s2 = new Softver("softver1", "naziv1", "proizvodjac", "sajt", 2007, 20000, "", OS.svejedno);
            
            Softveri.Add(s1);
            Softveri.Add(s2);
            this.DataContext = this;
            InitializeComponent();
        }

        private Softver selectedSoftver;
        private string v;

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

        public ObservableCollection<Softver> Softveri
        {
            get;
            set;
        }


        private void Izaberi_Click(object sender, RoutedEventArgs e)
        {
            PredmetiPage.getInstance().SelectedPredmet.NeophodanSoftver = SelectedSoftver;
            this.Close();
        }
    }
}
