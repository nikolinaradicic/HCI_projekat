using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    public class Softver
    {
        private string id;
        private string naziv;
        private string proizvodjac;
        private string sajt;
        private int godinaIzdavanja;
        private double cijena;
        private string opis;

        public Softver(){}

        public Softver(string id, string naziv, string proizvodjac,
            string sajt, int godinaIzdavanja, double cijena, string opis)
        {
            this.id = id;
            this.naziv = naziv;
            this.proizvodjac = proizvodjac;
            this.sajt = sajt;
            this.godinaIzdavanja = godinaIzdavanja;
            this.cijena = cijena;
            this.opis = opis;
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

    }

}
