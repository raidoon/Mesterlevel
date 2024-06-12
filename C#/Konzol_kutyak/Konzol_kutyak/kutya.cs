using System;
namespace Konzol_kutyak
{
    internal class kutya
    {
        public int kutyaid {  get; set; }
        public int fajtaid { get; set; }
        public string fajtanev { get; set; }
        public int nevekid { get; set; }
        public string kutyanev {  get; set; }
        public int eletkor {  get; set; }
        public DateTime ellenorzes { get; set; }
        public kutya (string sor)
        {
            string[] sz = sor.Split(';');
            kutyaid = int.Parse(sz[0]);
            fajtaid = int.Parse(sz[1]);
            nevekid = int.Parse(sz[2]);
            eletkor = int.Parse(sz[3]);
            ellenorzes = Convert.ToDateTime(sz[4]);
        }
    }
}