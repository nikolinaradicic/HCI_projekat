﻿using System;
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

    public class Predmet: INotifyPropertyChanged
    {
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
            bool tabla, bool pametnaTabla, Smjer smjer, OS neophodanOS, Softver neophodanSoftver)
        {
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
                neophodanOS = value;
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
                naziv = value;
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

        public int VelicinaGrupe
        {
            get
            {
                return velicinaGrupe;
            }
            set
            {
                velicinaGrupe = value;
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
               minDuzinaTermina = value;
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
                brojTermina = value;
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

        internal static void sacuvajPredmete(List<Predmet> list)
        {

            StreamWriter f = new StreamWriter(@".\..\..\files\predmeti.txt");
            foreach (Predmet s in list)
            {
                f.WriteLine(s.Id + "|" + s.Naziv + "|" + s.Opis + "|" + s.VelicinaGrupe + "|" + s.MinDuzinaTermina + "|" + s.BrojTermina + "|"
                    + s.Projektor + "|" + s.Tabla + "|" + s.PametnaTabla + "|" + s.Smjer.Id + "|"  + (int) s.NeophodanOS + "|" + s.NeophodanSoftver.Id);
            }
            f.Close();
        }
    }
}
