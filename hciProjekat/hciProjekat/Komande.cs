using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hciProjekat
{
    public static class Komande
    {
        public static readonly RoutedUICommand Izmijeni = new RoutedUICommand(
          "Izmijeni",
          "Izmijeni",
          typeof(Komande),
          new InputGestureCollection()
          {
                new KeyGesture(Key.U, ModifierKeys.Control),
            }
          );
    }
}
