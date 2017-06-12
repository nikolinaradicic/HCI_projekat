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
    public class Ucionica:INotifyPropertyChanged
    {
        private string id;
        private string opis;
        private int brojMjesta;
        private bool projektor;
        private bool tabla;
        private bool pametnaTabla;
        private List<Softver> instaliraniSoftver;
        private OS instaliranOS;

        [field:NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public List<Softver> InstaliraniSoftver
        {
            get
            {
                return instaliraniSoftver;
            }
            set
            {
                instaliraniSoftver = value;
            }
        }

        public Ucionica()
        {
            instaliraniSoftver = new List<Softver>();
        }

        public static ObservableCollection<Ucionica> ucitajUcionice()
        {
            ObservableCollection<Ucionica> ucionice = new ObservableCollection<Ucionica>();

            string[] lines = System.IO.File.ReadAllLines(@".\..\..\files\ucionice.txt");

            foreach (string ss in lines)
            {
                Ucionica u = new Ucionica();
                if (ss == "")
                    return ucionice;

                string[] param = ss.Split('|');

                u.Id = param[0];
                u.Opis = param[1];
                u.brojMjesta = Convert.ToInt32(param[2]);
                u.Projektor = Convert.ToBoolean(param[3]);
                u.Tabla = Convert.ToBoolean(param[4]);
                u.PametnaTabla = Convert.ToBoolean(param[5]);
                u.InstaliranOS = (OS) Convert.ToInt32(param[6]);
                string[] id_softvera = param[7].Split(',');
                List<Softver> softveri = SoftverPage.getInstance().Softveri.ToList();
                foreach(string s_id in id_softvera)
                {
                    Softver found = softveri.Find(i => i.Id.Equals(s_id));
                    u.instaliraniSoftver.Add(found);
                }
                ucionice.Add(u);
            }

            return ucionice;
        }

        public Ucionica(string id, string opis, int brojMjesta,
            bool projektor, bool tabla, bool pametnaTabla, List<Softver> softver, OS instaliranOS)
        {
            this.id = id;
            this.opis = opis;
            this.brojMjesta = brojMjesta;
            this.projektor = projektor;
            this.tabla = tabla;
            this.pametnaTabla = pametnaTabla;
            this.instaliraniSoftver = softver;
            this.instaliranOS = instaliranOS;
        }

        public OS InstaliranOS
        {
            get
            {
                return instaliranOS;
            }
            set
            {
                instaliranOS = value;
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

        public int BrojMjesta
        {
            get
            {
                return brojMjesta;
            }
            set
            {
                if(brojMjesta != value)
                {
                    brojMjesta = value;
                    OnPropertyChanged("BrojMjesta");
                }
            }
        }

        public bool Projektor
        {
            get
            {
                return projektor;
            }
            set
            {
                projektor = value;
            }
        }

        public bool Tabla
        {
            get
            {
                return tabla;
            }
            set
            {
                tabla = value;
            }
        }

        public bool PametnaTabla
        {
            get
            {
                return pametnaTabla;
            }
            set
            {
                pametnaTabla = value;
            }
        }

        internal static void sacuvajUcionice(List<Ucionica> list)
        {
            StreamWriter f = new StreamWriter(@".\..\..\files\ucionice.txt");
            foreach (Ucionica s in list)
            {
                string line = s.Id + "|" + s.Opis + "|" + (int)s.BrojMjesta + "|" + s.Projektor + "|" + s.Tabla + "|"
                      + s.PametnaTabla + "|" + (int)s.InstaliranOS + "|";
                for(int i = 0; i < s.InstaliraniSoftver.Count; i++)
                {
                    line += s.InstaliraniSoftver[i].Id;
                    if (i != s.InstaliraniSoftver.Count - 1)
                    {
                        line += ",";
                    }
                }
                
                f.WriteLine(line);
            }
            f.Close();
        }
    }
}
