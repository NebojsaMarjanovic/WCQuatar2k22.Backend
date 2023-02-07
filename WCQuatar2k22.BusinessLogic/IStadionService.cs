using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.BusinessLogic
{
    public interface IStadionService
    {
        Task<List<Stadion>> GetStadioni();

        Task<List<Stadion>> GetSlobodniStadioni(DateTime vremeOdrzavanja);
    }
}
