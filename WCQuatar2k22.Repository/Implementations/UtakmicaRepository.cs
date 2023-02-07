using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WCQuatar2k22.Domain.Domain;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.Interfaces;

namespace WCQuatar2k22.Repository.Implementations
{
    public class UtakmicaRepository : IUtakmicaRepository
    {
        private readonly Context _context;

        public UtakmicaRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> Add(Utakmica entity)
        {
            await _context.AddAsync(entity);
            return entity.UtakmicaId;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Utakmica>> GetAll()
        {
            return  await _context.Utakmica.Include(x=>x.Domacin)
                .Include(x=>x.Gost).ToListAsync();
        }

        public async Task<List<Utakmica>> SearchBy(Expression<Func<Utakmica, bool>> predicate)
        {
            return await _context.Utakmica.Include(x=>x.Stadion).Include(x=>x.Gost).Include(x=>x.Domacin).Where(predicate).ToListAsync();
        }

        public async Task<Utakmica> SearchById(object id)
        {
            return  await _context.Utakmica.Include(x=>x.Domacin).Include(x=>x.Gost).FirstAsync(x=>x.UtakmicaId==(int)id);
        }

        public Task<Utakmica> Update(Utakmica entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRezultat(int utakmicaId, int domacinRezultat, int gostRezultat)
        {
            var utakmica = await SearchById(utakmicaId);
            utakmica.DomacinRezultat = domacinRezultat;
            utakmica.GostRezultat = gostRezultat;
            _context.Utakmica.Attach(utakmica).State = EntityState.Modified;
        }
    }
}
