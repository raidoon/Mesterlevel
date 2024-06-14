namespace ConsoleApp_Csincsilla
{
    internal class Csincsillaadatok
    {
        public string Nev { get; set; }
        public string Szul { get; set; }
        public int Suly { get; set; }
        public string Simi { get; set; }
        public Csincsillaadatok(string sor)
        {
            string[] sz = sor.Split(';');
            Nev = sz[0];
            Szul = sz[1];
            Suly = int.Parse(sz[2]);
            Simi = sz[3];
        }
    }
}