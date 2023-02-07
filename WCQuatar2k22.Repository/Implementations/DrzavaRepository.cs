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

        public async Task UpdateBodovi(int drzavaId, int bodovi)
        {
            var drzava = await SearchById(drzavaId);
            drzava.OsvojeniPoeni += bodovi;
            _context.Drzava.Attach(drzava).Property(x => x.OsvojeniPoeni).IsModified = true;
        }
    }
}
