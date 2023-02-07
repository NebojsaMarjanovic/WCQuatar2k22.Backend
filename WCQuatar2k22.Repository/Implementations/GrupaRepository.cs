using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WCQuatar2k22.Domain.Domain;
using WCQuatar2k22.Domain.Models;
using WCQuatar2k22.Repository.Interfaces;

namespace WCQuatar2k22.Repository.Implementations
{
    public class GrupaRepository : IGrupaRepository
    {
        private readonly Context _context;

        public GrupaRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> Add(Grupa entity)
        {
            await _context.Grupa.AddAsync(entity);
            _context.SaveChanges();
            return entity.GrupaId;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Grupa>> GetAll()
        {
            return await _context.Grupa.Include(g => g.Drzave.OrderByDescending(x=>x.OsvojeniPoeni)).ToListAsync();
        }

        public Task<List<Grupa>> SearchBy(Expression<Func<Grupa, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Grupa> SearchById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Grupa> Update(Grupa entity)
        {
            throw new NotImplementedException();
        }
    }
}
