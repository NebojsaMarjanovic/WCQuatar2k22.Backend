using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WCQuatar2k22.Domain.Domain;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.Interfaces;

namespace WCQuatar2k22.Repository.Implementations
{
    public class DrzavaRepository : IDrzavaRepository
    {

        private readonly Context _context;

        public DrzavaRepository(Context context)
        {
            _context = context;
        }

        public async Task UpdateGrupa(int drzavaId, int grupaId)
        {
            var drzava = await SearchById(drzavaId);
            drzava.GrupaId = grupaId;
            _context.Drzava.Attach(drzava).Property(x => x.GrupaId).IsModified = true;
        }

        public Task<int> Add(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Drzava>> GetAll()
        {
            return await _context.Drzava.ToListAsync();
        }

        public async Task<List<Drzava>> SearchBy(Expression<Func<Drzava, bool>> predicate)
        {
            return await _context.Drzava.Where(predicate).ToListAsync();
        }

        public async Task<Drzava> SearchById(object id)
        {
            return await _context.Drzava.FindAsync(id);
        }

        public async Task<Drzava> Update(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBodovi(int drzavaId, int postignutiGolovi, int primljeniGolovi, int bodovi)
        {
            var drzava = await SearchById(drzavaId);
            drzava.OsvojeniPoeni += bodovi;
            drzava.BrojOdigranihMeceva++;
            drzava.BrojDatihGolova += postignutiGolovi;
            drzava.BrojPrimljenihGolova += primljeniGolovi;
            //_context.Drzava.Attach(drzava).Property(x => x.OsvojeniPoeni).IsModified = true;
            //_context.Drzava.Attach(drzava).Property(x => x.BrojOdigranihMeceva).IsModified = true;


            switch (bodovi)
            {
                case 3:
                    drzava.BrojPobeda++;
                    //_context.Drzava.Attach(drzava).Property(x => x.BrojPobeda).IsModified = true;
                    break;
                case 1:
                    drzava.BrojNeresenih++;
                    //_context.Drzava.Attach(drzava).Property(x => x.BrojNeresenih).IsModified = true;
                    break;
                case 0:
                    drzava.BrojIzgubljenih++;
                    //_context.Drzava.Attach(drzava).Property(x => x.BrojIzgubljenih).IsModified = true;
                    break;
            }
            //_context.Drzava.Update(drzava);
            _context.Drzava.Attach(drzava).State = EntityState.Modified;

        }

        public async Task IzmeniDrzaveUGrupi(int grupaId, int staraDrzava, int novaDrzava)
        {
            var stara = await SearchById(staraDrzava);
            var nova = await SearchById(novaDrzava);

            stara.GrupaId = null;
            nova.GrupaId = grupaId;

            _context.Drzava.Attach(stara).Property(x => x.GrupaId).IsModified = true;
            _context.Drzava.Attach(nova).Property(x => x.GrupaId).IsModified = true;

        }
    }
}
