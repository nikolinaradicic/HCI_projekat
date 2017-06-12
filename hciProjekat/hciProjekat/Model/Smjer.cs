using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    [Serializable]
    public class Smjer
    {
        private string id;
        private string naziv;
        private string opis;
        private string datumUvodjenja;
        

        public Smjer(){}

        public Smjer(string id, string naziv, string opis, string datumUvodjenja)
        {
            this.id = id;
            this.naziv = naziv;
            this.opis = opis;
            this.datumUvodjenja = datumUvodjenja;
            
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

        public static void sacuvajSmjerove(List<Smjer> smjerovi)
        {
            StreamWriter f = new StreamWriter(@".\..\..\files\smjerovi.txt");
            foreach (Smjer s in smjerovi)
            {
                f.WriteLine(s.Id + "|" + s.Opis + "|" + s.Naziv + "|" + s.DatumUvodjenja);
            }
            f.Close();
        }

        public static ObservableCollection<Smjer> ucitajSmjerove()
        {
            ObservableCollection<Smjer> smjerovi = new ObservableCollection<Smjer>();

            string[] lines = System.IO.File.ReadAllLines(@".\..\..\files\smjerovi.txt");

            foreach (string ss in lines)
            {
                Smjer s = new Smjer();
                if (ss == "")
                    return smjerovi;

                string[] param = ss.Split('|');

                s.Id = param[0];
                s.Opis = param[1];
                s.Naziv = param[2];
                s.datumUvodjenja = param[3];
                smjerovi.Add(s);
            }

            return smjerovi;
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
        public string DatumUvodjenja
        {
            get
            {
                return datumUvodjenja;
            }
            set
            {
                datumUvodjenja = value;
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
    }
}
