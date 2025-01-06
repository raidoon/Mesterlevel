using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karacsonyCLI
{
    public class Adatsor
    {
        public int nap { get; set; }
        public int keszharang { get; set; }
        public int eladottharang { get; set; }
        public int keszangyal {  get; set; }
        public int eladottangyal { get; set; }
        public int keszfenyo { get; set; }
        public int eladottfenyo { get; set; }
        internal int NapiBevetel()
        {
            return -(eladottharang * 1000 + eladottangyal * 1350 + eladottfenyo * 1500);
        }
    }
}