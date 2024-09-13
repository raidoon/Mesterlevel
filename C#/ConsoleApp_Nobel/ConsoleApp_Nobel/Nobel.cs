using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Nobel
{
    public class Nobel
    {
        //év;típua;keresztnév;vezetéknév
        public int ev { get; set; }
        public string tipus { get; set; }
        public string keresztNev { get; set; }
        public string vezetekNev { get; set; }

        public Nobel(string sor)
        {
            string[] n= sor.Split(';');
            ev = int.Parse(n[0]);
            tipus = n[1];
            keresztNev = n[2];
            vezetekNev = n[3];
        }
    }
}