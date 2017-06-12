using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    [Serializable]
    public class Softver
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
                operativniSistem = value;
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
                id = value;
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
                naziv = value;
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
                proizvodjac = value;
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
                sajt = value;
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
                godinaIzdavanja = value;
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
                opis = value;
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
