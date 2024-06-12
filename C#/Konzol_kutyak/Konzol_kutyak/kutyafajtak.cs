namespace Konzol_kutyak
{
    internal class kutyafajtak
    {
        public int fajtaid { get; set; }
        public string fajtanev { get; set; }
        public string fajtaeredetiNev { get; set; }
        public kutyafajtak(string sor)
        {
            string[] sz = sor.Split(';');
            fajtaid = int.Parse(sz[0]);
            fajtanev = sz[1];
            fajtaeredetiNev = sz[2];
        }
    }
}