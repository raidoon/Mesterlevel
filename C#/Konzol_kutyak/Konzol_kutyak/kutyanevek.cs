namespace Konzol_kutyak
{
    internal class kutyanevek
    {
        public int id { get; set; }
        public string kutyanev { get; set; }
        public kutyanevek(string sor)
        {
            string[] sz = sor.Split(';');
            id = int.Parse(sz[0]);
            kutyanev = sz[1];
        }
    }
}