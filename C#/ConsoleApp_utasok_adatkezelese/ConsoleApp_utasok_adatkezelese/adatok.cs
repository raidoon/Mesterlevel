using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_utasok_adatkezelese
{
    internal class adatok
    {
        //0 20190326-0700 4170861 NYB 20190404
        //0 20190326-0700 6915170 FEB 20210101
        public int MegalloSorszam { get; set; }
        public string FelszallasDatumIdo { get; set; } //ééééhhnn-óópp
        public string KartyaAzon { get; set; } //nem számolunk vele, úgyhogy maradhat string
        public string BerletTipus { get; set; }
        public string ErvenyessegiDatum {get;set;}

        public adatok(string sor)
        {
            string[] n = sor.Split(' ');
            MegalloSorszam = int.Parse(n[0]);
            FelszallasDatumIdo = n[1];
            KartyaAzon = n[2];
            BerletTipus = n[3];
            ErvenyessegiDatum = n[4];
        }
        //csak érvényes jeggyel vagy bérlettel lehet utazni
        public bool ervenyessegEllenorzes()
        {
            if (ErvenyessegiDatum.Length <= 2) return ErvenyessegiDatum != "0";
            else
            {
                DateTime felszallasDatuma = DateTime.ParseExact(FelszallasDatumIdo.Split('-')[0], "yyyyMMdd", CultureInfo.InvariantCulture);
                DateTime ervenyessegDatuma = DateTime.ParseExact(ErvenyessegiDatum, "yyyyMMdd", CultureInfo.InvariantCulture);
                return ervenyessegDatuma>=felszallasDatuma;
            }
        }

        //bérletekre függvény
        public bool kedvezmenyes()
        {
            if (BerletTipus == "TAB" || BerletTipus == "NYB") return true;
            else return false;
        }
        public bool ingyenes()
        {
            if (BerletTipus == "NYP" || BerletTipus == "RVS" || BerletTipus=="GYK") return true;
            else return false;
        }
    }
}