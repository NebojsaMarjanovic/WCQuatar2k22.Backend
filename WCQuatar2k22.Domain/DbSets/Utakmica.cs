namespace WCQuatar2k22.Domain.Models
{
    public class Utakmica
    {
        public int UtakmicaId { get; set; }
        public Drzava Domacin { get; set; }
        public int DomacinId { get; set; }
        public Drzava Gost { get; set; }
        public int GostId { get; set; }
        public int? DomacinRezultat { get; set; }
        public int? GostRezultat { get; set; }
        public DateTime VremeOdrzavanja { get; set; }
        public Stadion Stadion { get; set; }
        public int StadionId { get; set; }
        public bool PredajaMeca { get; set; }
    }
}
