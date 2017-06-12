using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    public class Raspored : INotifyPropertyChanged
    {
     

        Dictionary<string, List<Termin>> termini;

        public Raspored() {
            termini= new Dictionary<string, List<Termin>>();
        }

        public Dictionary<string, List<Termin>> Termini {
            get { return termini; }
            set { termini = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
