using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.Repository.Interfaces
{
    public interface IUtakmicaRepository:IRepository<Utakmica>
    {
        Task UpdateRezultat(int utakmicaId, int domacinRezultat, int gostRezultat);
    }
}
