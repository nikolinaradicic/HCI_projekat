using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    public class Ucionica
    {
        private string id;
        private string opis;
        private int brojMjesta;
        private bool projektor;
        private bool tabla;
        private bool pametnaTabla;
        private List<Softver> instaliraniSoftver;
        private OS instaliranOS;

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

        public Ucionica(string id, string opis, int brojMjesta,
            bool projektor, bool tabla, bool pametnaTabla, List<Softver> softver)
        {
            this.id = id;
            this.opis = opis;
            this.brojMjesta = brojMjesta;
            this.projektor = projektor;
            this.tabla = tabla;
            this.pametnaTabla = pametnaTabla;
            this.instaliraniSoftver = softver;
        }

        public OS InstaliranOS
        {
            get
            {
                return InstaliranOS;
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
                brojMjesta = value;
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
        
    }
}
