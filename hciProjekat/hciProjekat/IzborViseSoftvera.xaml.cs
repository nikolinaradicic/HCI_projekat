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
    /// Interaction logic for IzborViseSoftvera.xaml
    /// </summary>
    /// 
    public class SoftverStavka: INotifyPropertyChanged
    { 
        public Softver Softver
        {
            get;
            set;
        }
        private bool odabran;

        public SoftverStavka(Softver s)
        {
            this.Softver = s;
        }

        public bool Odabran
        {
            get
            {
                return odabran;
            }
            set
            {
                if(odabran != value)
                {
                    odabran = value;
                    OnPropertyChanged("Odabran");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


    }
    public partial class IzborViseSoftvera : Window
    {
        public ObservableCollection<SoftverStavka> Softveri
        {
            get;
            set;
        }

        public IzborViseSoftvera(List<Softver> odabrani)
        {
            Softveri = new ObservableCollection<SoftverStavka>();
            ObservableCollection<Softver> svi = SoftverPage.getInstance().Softveri;
            foreach(Softver s in svi){
                SoftverStavka stavka = new SoftverStavka(s);
                if (odabrani.Contains(s))
                {
                    stavka.Odabran = true;
                }
                else
                {
                    stavka.Odabran = false;
                }
                Softveri.Add(stavka);
            }
            this.DataContext = this;
            InitializeComponent();
        }


        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            List<Softver> odabrani = new List<Softver>();
            foreach(SoftverStavka ss in Softveri)
            {
                if (ss.Odabran)
                {
                    odabrani.Add(ss.Softver);
                }
            }
            UcionicePage.getInstance().SelectedUcionica.InstaliraniSoftver = odabrani;
            this.Close();
        }
    }
}
