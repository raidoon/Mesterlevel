using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Nobel
{
    internal class class_maskeppen
    {
        public int ev;
        public string tipus;
        public string keresztNev;
        public string vezetekNev;

        public class_maskeppen(int ev, string tipus, string keresztNev, string vezetekNev)
        {
            this.ev = ev;
            this.tipus = tipus;
            this.keresztNev = keresztNev;
            this.vezetekNev = vezetekNev;
        }
    }
}