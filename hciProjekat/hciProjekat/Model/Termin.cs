using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hciProjekat.Model
{
    public class Termin : INotifyPropertyChanged
    {
        private string vremeTermina;

        public string VremeTermina
        {
            get
            {
                return vremeTermina;
            }
            set
            {
                    vremeTermina = value;
            }
        }

        //public static ObservableCollection<Termin> ucitajVreme()
        //{
        //    ObservableCollection<Termin> termini = new ObservableCollection<Termin>();

        //    string[] lines = System.IO.File.ReadAllLines(@".\..\..\files\termini.txt");

        //    foreach (string ss in lines)
        //    {
        //        Termin t = new Termin();
        //        string[] tokens = ss.Split(' ');
        //        if (ss == "")
        //            return termini;
        //        t.vremeTermina = tokens[0];
        //        termini.Add(t);
        //    }

        //    return termini;

        //}


        public static ObservableCollection<Termin> ucitajTermine()
        {
            ObservableCollection<Termin> termini = new ObservableCollection<Termin>();

            string[] lines = File.ReadAllLines(@".\..\..\files\termini.txt");

            foreach (string ss in lines)
            {
                Termin t = new Termin();
                string[] tokens = ss.Split(' ');
                if (ss == "")
                    return termini;
                t.vremeTermina = tokens[1];        
                termini.Add(t);
            }

            return termini;

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
