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
    public class StadionRepository : IStadionRepository
    {

        private readonly Context _context;

        public StadionRepository(Context context)
        {
            _context = context;
        }

        public Task<int> Add(Stadion entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Stadion>> GetAll()
        {
            return await _context.Stadion.ToListAsync();
        }

        public async Task<List<Stadion>> SearchBy(Expression<Func<Stadion, bool>> predicate)
        {
            return await _context.Stadion.Where(predicate).ToListAsync();
        }

        public Task<Stadion> SearchById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Stadion> Update(Stadion entity)
        {
            throw new NotImplementedException();
        }
    }
}
