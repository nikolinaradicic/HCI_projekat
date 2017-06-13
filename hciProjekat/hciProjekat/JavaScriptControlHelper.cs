using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace hciProjekat
{
   
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [ComVisible(true)]
        class JavaScriptControlHelper
        {
            MainWindow prozor;
            PredmetiPage dodajPredmet;
            public JavaScriptControlHelper(MainWindow w)
            {
                prozor = w;
            }

            public JavaScriptControlHelper(PredmetiPage w)
            {
                dodajPredmet = w;
            }

        public void RunFromJavascript(string param)
            {
                prozor.doThings(param);
            }
        }
    }

