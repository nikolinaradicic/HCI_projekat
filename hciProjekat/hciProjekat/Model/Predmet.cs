using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    public enum OS { widows, linux, svejedno };

    public class Predmet
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
                smjer = value;
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

        public int MInDuzinaTermina
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


    }
}
