using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Repository.Interfaces;

namespace WCQuatar2k22.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IDrzavaRepository DrzavaRepository { get; set; }
        public IGrupaRepository GrupaRepository { get; set; }
        public IStadionRepository StadionRepository { get; set; }
        public IUtakmicaRepository UtakmicaRepository { get; set; }

        public Task Save();

    }
}
