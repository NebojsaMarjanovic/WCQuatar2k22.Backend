using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.BusinessLogic
{
    public interface IDrzavaService
    {
        Task<List<Drzava>> GetRaspoloziveDrzave(DateTime vremeOdrzavanja, int grupaId);
        Task<List<Drzava>> GetDrzave();
        Task IzmeniDrzaveUGrupi(int grupaId, int staraDrzava, int novaDrzava);
    }
}
