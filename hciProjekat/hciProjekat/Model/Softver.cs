using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    [Serializable]
    public class Softver:INotifyPropertyChanged
    {
        private string id;
        private string naziv;
        private string proizvodjac;
        private string sajt;
        private int godinaIzdavanja;
        private double cijena;
        private string opis;
        private OS operativniSistem;

        public Softver(){}

        public Softver(string id, string naziv, string proizvodjac,
            string sajt, int godinaIzdavanja, double cijena, string opis, OS operativniSistem)
        {
            this.id = id;
            this.naziv = naziv;
            this.proizvodjac = proizvodjac;
            this.sajt = sajt;
            this.godinaIzdavanja = godinaIzdavanja;
            this.cijena = cijena;
            this.opis = opis;
            this.operativniSistem = operativniSistem;
        }

        public OS OperativniSistem
        {
            get
            {
                return operativniSistem;
            }
            set
            {
                if (operativniSistem != value)
                {
                    operativniSistem = value;
                    OnPropertyChanged("OperativniSistem");
                }
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

       
        public string Proizvodjac
        {
            get
            {
                return proizvodjac;
            }
            set
            {
                if (proizvodjac != value)
                {
                    proizvodjac = value;
                    OnPropertyChanged("Proizvodjac");
                }
            }
        }

        public string Sajt
        {
            get
            {
                return sajt;
            }
            set
            {
                if (sajt != value)
                {
                    sajt = value;
                    OnPropertyChanged("Sajt");
                }
            }
        }

        public int GodinaIzdavanja
        {
            get
            {
                return godinaIzdavanja;
            }
            set
            {
                if(godinaIzdavanja != value)
                {
                    godinaIzdavanja = value;
                    OnPropertyChanged("GodinaIzdavanja");
                }
            }
        }

        public double Cijena
        {
            get
            {
                return cijena;
            }
            set
            {
                if(cijena != value)
                {
                    cijena = value;
                    OnPropertyChanged("Cijena");
                }
                cijena = value;
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (opis != value)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public static ObservableCollection<Softver> ucitajSoftver()
        {
            ObservableCollection<Softver> softver = new ObservableCollection<Softver>();

            string[] lines = File.ReadAllLines(@".\..\..\files\softver.txt");

            foreach (string ss in lines)
            {
                Softver s = new Softver();
                if (ss == "")
                    return softver;

                string[] param = ss.Split('|');

                s.Id = param[0];
                s.Naziv = param[1];
                s.Cijena = Convert.ToDouble(param[2]);
                s.Opis = param[3];
                s.Proizvodjac = param[4];
                s.Sajt = param[5];
                s.OperativniSistem = (OS)Convert.ToInt32(param[6]);
                s.GodinaIzdavanja = Convert.ToInt32(param[7]);



                softver.Add(s);
            }

            return softver;
        }

        internal static void sacuvajSoftver(List<Softver> list)
        {
            StreamWriter f = new StreamWriter(@".\..\..\files\softver.txt");
            foreach (Softver s in list)
            {
                f.WriteLine(s.Id + "|" + s.Naziv + "|" + s.Cijena + "|" + s.Opis + "|" + s.Proizvodjac + "|" + s.Sajt + "|"
                    + (int) s.OperativniSistem + "|" + s.GodinaIzdavanja);
            }
            f.Close();
        }
    }

}
