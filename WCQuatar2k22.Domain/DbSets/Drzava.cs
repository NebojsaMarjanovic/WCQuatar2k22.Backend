namespace WCQuatar2k22.Domain.Models
{
    public class Drzava
    {
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public string Zastava { get; set; }
        public int BrojOdigranihMeceva { get; set; }
        public int BrojPobeda { get; set; }
        public int BrojNeresenih { get; set; }
        public int BrojIzgubljenih { get; set; }
        public int BrojPrimljenihGolova { get; set; }
        public int BrojDatihGolova { get; set; }
        public int OsvojeniPoeni { get; set; }
        public int Sesir { get; set; }
        public Grupa? Grupa { get; set; }
        public int? GrupaId { get; set; }


    }
}
