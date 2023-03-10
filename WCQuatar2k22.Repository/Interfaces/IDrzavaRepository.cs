using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Models;

namespace WCQuatar2k22.Repository.Interfaces
{
    public interface IDrzavaRepository:IRepository<Drzava>
    {
        Task UpdateGrupa(int drzavaId, int grupaId);
        Task UpdateBodovi(int drzavaId, int postignutiGolovi, int primljeniGolovi, int bodovi);
        Task IzmeniDrzaveUGrupi(int grupaId, int staraDrzava, int novaDrzava);
    }
}
