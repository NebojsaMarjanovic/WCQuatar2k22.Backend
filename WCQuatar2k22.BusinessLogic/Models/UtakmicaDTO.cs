using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.BusinessLogic.Models
{
    public class UtakmicaDTO
    {
        public int DomacinId { get; set; }
        public int GostId { get; set; }
        public int? DomacinRezultat { get; set; }
        public int? GostRezultat { get; set; }
        public DateTime VremeOdrzavanja { get; set; }
        public int StadionId { get; set; }
    }
}
