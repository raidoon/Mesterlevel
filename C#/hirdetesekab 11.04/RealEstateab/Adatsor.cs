using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateab
{
    public class Adatsor
    {
        //SELECT hirdetesekid,szobaszam,szelesseg,hosszusag,emelet,alapterulet,hirdetesszoveg,tehermentes,kepurl,hirdetesdatum,hirdetoid,hirdetonev,hirdetotelefon,kategoriaid,kategorianev FROM kategoriak INNER JOIN hirdetesek ON kategoriaid=kategoriakid INNER JOIN hirdetok ON hirdetoid=hirdetokid
        public int hirdetesekid { get; set; }//pl 1
        public int szobaszam { get; set; }// pl 5        
        public double szelesseg { get; set; }//47.5410485803319
        public double hosszusag { get; set; }//19.1516419487702
        public int emelet { get; set; }//pl 0 földszint
        public int alapterulet { get; set; }//pl 165 (nméter)
        public string hirdetesszoveg { get; set; }//üres
        public bool tehermentes { get; set; }//pl 1=tehermentes
        public string kepUrl { get; set; }//pl https://drive.google.com/file/d/1qs5XyJNnnT_meJn_qVJLwASvY1By2bVj
        public DateTime hirdetesdatum { get; set; }//pl 2021-11-17
        public int hirdetoid { get; set; }//pl 56
        public string hirdetonev { get; set; }//pl Fazekas Zoltán
        public string hirdetotelefon { get; set; }//pl +36 1 9929-8217
        public int kategoriaid { get; set; }//pl 1
        public string kategorianev { get; set; }//pl ház
        public double DistanceTo(double szel, double hossz)
        {
            double a = Math.Abs(hossz - hosszusag);
            double b = Math.Abs(szel - szelesseg);
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }
}
