using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat.Model
{
    [Serializable]
    class UcionicaRaspored
    {
        private Ucionica ucionica;
        
        private List<List<ObservableCollection<Predmet>>> odrzavaniPredmeti;

        
        public UcionicaRaspored() {
            odrzavaniPredmeti = new List<List<ObservableCollection<Predmet>>>();
            for (int i = 0; i < 61; i++)
            {
                List<ObservableCollection<Predmet>> temp = new List<ObservableCollection<Predmet>>();
                for (int j = 0; j < 7; j++)
                {
                    temp.Add(new ObservableCollection<Predmet>());
                }
                odrzavaniPredmeti.Add(temp);
            }
        }

        public Ucionica Ucionica{
            get { return ucionica; }
            set { ucionica = value; }
        }

        public List<List<ObservableCollection<Predmet>>> OdrzavaniPredmeti{
            get { return odrzavaniPredmeti; }
            set { odrzavaniPredmeti = value; }

        }
    }
}
