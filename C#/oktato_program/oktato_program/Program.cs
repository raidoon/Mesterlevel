using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oktato_program
{
    internal class Program
    {
        public static int valasz = 0, a = 0, b = 0, muvelet = 0;
        public static string muveletjel = "";
        static void Main(string[] args)
        {
            //mennyi [véletlen szám x] + [véletlen szám y] = [kérje be a választ] 10x csinálja meg
            // plusz és minusz is véletlen legyen
            //max 20ig legyenek a véletlen számok
            int eredmeny = 0, pontszam = 0;

            int pluszminusz = 1;
            for (int i = 0; i < 10; i++) 
            {
                if (pluszminusz%2==0) //osszeadas
                {
                    pluszminusz--;

                }
                else //kivonas
                {
                    pluszminusz++;
                }
            }


            Console.ReadKey();
        }
    }
}
