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
    public enum OS { widows, linux, svejedno };

    [Serializable]
    public class Predmet: INotifyPropertyChanged
    {
        private int pomocni_broj_termina;
        private int pomocni_broj;
        private string id;
        private string naziv;
        private string opis;
        private int velicinaGrupe;
        private int minDuzinaTermina;
        private int brojTermina;
        private bool projektor;
        private bool tabla;
        private bool pametnaTabla;
        private Smjer smjer;
        private OS neophodanOS;
        private Softver neophodanSoftver;

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public Predmet() { }

        public Predmet(string id, string naziv, string opis, int velicinaGrupe, int duzinaTermina, int brojTermina, bool projektor,
            bool tabla, bool pametnaTabla, Smjer smjer, OS neophodanOS, Softver neophodanSoftver, int pomocni_broj_termina)
        {
            this.pomocni_broj_termina = pomocni_broj_termina;
            pomocni_broj = -1;
            this.id = id;
            this.naziv = naziv;
            this.opis = opis;
            this.velicinaGrupe = velicinaGrupe;
            this.minDuzinaTermina = duzinaTermina;
            this.brojTermina = brojTermina;
            this.projektor = projektor;
            this.tabla = tabla;
            this.pametnaTabla = pametnaTabla;
            this.smjer = smjer;
            this.neophodanOS = neophodanOS;
            this.neophodanSoftver = neophodanSoftver;
        }

        public Predmet(Predmet p) {
            pomocni_broj_termina = 1;
            pomocni_broj = -1;
            this.id = p.id;
            this.naziv = p.naziv;
            this.opis = p.opis;
            this.velicinaGrupe = p.velicinaGrupe;
            this.minDuzinaTermina = p.minDuzinaTermina;
            this.brojTermina = p.brojTermina;
            this.projektor = p.projektor;
            this.tabla = p.tabla;
            this.pametnaTabla = p.pametnaTabla;
            this.smjer = p.smjer;
            this.neophodanOS = p.neophodanOS;
            this.neophodanSoftver = p.neophodanSoftver;
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

        public int PomocniBrojTermina
        {
            get
            {
                return pomocni_broj_termina;
            }
            set
            {
                pomocni_broj_termina= value;
            }
        }

        public Smjer Smjer
        {
            get
            {
                return smjer;
            }
            set
            {
                if(smjer != value)
                {

                    smjer = value;
                    OnPropertyChanged("Smjer");
                }
            }
        }

        public OS NeophodanOS
        {
            get
            {
                return neophodanOS;
            }
            set
            {
                if (neophodanOS != value)
                {
                    neophodanOS = value;
                    OnPropertyChanged("NeophodanOS");
                }
            }
        }

        public int PomocniBroj
        {
            get
            {
                return pomocni_broj;
            }
            set
            {
                if (pomocni_broj != value)
                {

                    pomocni_broj = value;
                    OnPropertyChanged("PomocniBroj");
                }
            }
        }


        public Softver NeophodanSoftver
        {
            get
            {
                return neophodanSoftver;
            }
            set
            {
                if(neophodanSoftver != value)
                {
                    neophodanSoftver = value;
                    OnPropertyChanged("NeophodanSoftver");
                }
            }
        }

        public static ObservableCollection<Predmet> ucitajPredmete()
        {
            ObservableCollection<Predmet> predmeti = new ObservableCollection<Predmet>();

            string[] lines = System.IO.File.ReadAllLines(@".\..\..\files\predmeti.txt");

            foreach (string ss in lines)
            {
                Predmet p = new Predmet();
                if (ss == "")
                    return predmeti;

                string[] param = ss.Split('|');

                p.Id = param[0];
                p.Opis = param[2];
                p.Naziv = param[1];
                p.velicinaGrupe = Convert.ToInt32(param[3]);
                p.minDuzinaTermina = Convert.ToInt32(param[4]);
                p.brojTermina = Convert.ToInt32(param[5]);
                p.projektor = Convert.ToBoolean(param[6]);
                p.Tabla = Convert.ToBoolean(param[7]);
                p.PametnaTabla = Convert.ToBoolean(param[8]);
                List<Smjer> smjerovi = SmjeroviPage.getInstance().Smjerovi.ToList();
                Smjer pronadjen = smjerovi.Find(s => s.Id.Equals(param[9]));
                p.smjer = pronadjen;
                p.neophodanOS = (OS)Convert.ToInt32(param[10]);
                List<Softver> softveri = SoftverPage.getInstance().Softveri.ToList();
                Softver pronadjen_s = softveri.Find(s => s.Id.Equals(param[11]));
                p.neophodanSoftver = pronadjen_s;
                p.PomocniBroj = Convert.ToInt32(param[12]);
                p.PomocniBrojTermina = Convert.ToInt32(param[13]);
                predmeti.Add(p);
            }

            return predmeti;

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

        public int VelicinaGrupe
        {
            get
            {
                return velicinaGrupe;
            }
            set
            {
                if(velicinaGrupe != value)
                {
                    velicinaGrupe = value;
                    OnPropertyChanged("VelicinaGrupe");
                }
            }
        }

        public int MinDuzinaTermina
        {
            get
            {
                return minDuzinaTermina;
            }
            set
            {
                if(minDuzinaTermina != value)
                {
                    minDuzinaTermina = value;
                    OnPropertyChanged("MinDuzinaTermina");
                }
            }
        }

        public int BrojTermina
        {
            get
            {
                return brojTermina;
            }
            set
            {
                if(brojTermina != value)
                {
                    brojTermina = value;
                    OnPropertyChanged("BrojTermina");
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
                if (projektor != value)
                {

                    projektor = value;
                    OnPropertyChanged("Projektor");
                }
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
                if (tabla != value)
                {
                    tabla = value;
                    OnPropertyChanged("Tabla");
                }
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
                if (pametnaTabla != value)
                {

                    pametnaTabla = value;
                    OnPropertyChanged("PametnaTabla");
                }
            }
        }

        internal static void sacuvajPredmete(List<Predmet> list)
        {

            StreamWriter f = new StreamWriter(@".\..\..\files\predmeti.txt");
            foreach (Predmet s in list)
            {
                f.WriteLine(s.Id + "|" + s.Naziv + "|" + s.Opis + "|" + s.VelicinaGrupe + "|" + s.MinDuzinaTermina + "|" + s.BrojTermina + "|"
                    + s.Projektor + "|" + s.Tabla + "|" + s.PametnaTabla + "|" + s.Smjer.Id + "|"  + (int) s.NeophodanOS + "|" + s.NeophodanSoftver.Id + "|"
                    + s.PomocniBroj + "|" + s.PomocniBrojTermina);
            }
            f.Close();
        }
    }
}
