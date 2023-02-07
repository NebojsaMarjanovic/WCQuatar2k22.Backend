using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Domain;
using WCQuatar2k22.Repository.Implementations;
using WCQuatar2k22.Repository.Interfaces;

namespace WCQuatar2k22.Repository.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
            DrzavaRepository = new DrzavaRepository(context);
            GrupaRepository = new GrupaRepository(context);
            StadionRepository = new StadionRepository(context);
            UtakmicaRepository = new UtakmicaRepository(context);

        }

        public IDrzavaRepository DrzavaRepository { get; set; }
        public IGrupaRepository GrupaRepository { get; set; }
        public IStadionRepository StadionRepository { get; set; }
        public IUtakmicaRepository UtakmicaRepository { get; set; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
