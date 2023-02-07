using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.BusinessLogic.Models;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.BusinessLogic
{
    public interface IGrupaService
    {
        Task DodajGrupu(GrupaDTO grupaDTO);
        Task<List<Grupa>> GetGrupe();
    }
}
