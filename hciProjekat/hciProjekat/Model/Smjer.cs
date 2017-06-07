using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    public class Smjer
    {
        private string id;
        private string naziv;
        private string opis;
        private DateTime datumUvodjenja;
        

        public Smjer(){}

        public Smjer(string id, string naziv, string opis, DateTime datumUvodjenja)
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
        public DateTime DatumUvodjenja
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
