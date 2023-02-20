namespace WCQuatar2k22.Domain.Models
{
    public class Grupa
    {
        public int GrupaId { get; set; }
        public string NazivGrupe { get; set; }
        public List<Drzava> Drzave { get; set; }
        public bool JeZakljucana { get; set; }
    }
}
