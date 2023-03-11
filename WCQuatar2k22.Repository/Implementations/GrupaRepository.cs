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

        public async Task Delete(int id)
        {
            //var drzave = await _context.Drzava.Where(x => x.GrupaId == id).ToListAsync();
            //foreach(var drzava in drzave)
            //{
            //    drzava.GrupaId = null;
            //    _context.Drzava.Update(drzava);
            //}
            var grupa = await SearchById(id);
            _context.Remove(grupa);
        }

        public async Task<List<Grupa>> GetAll()
        {
            return await _context.Grupa.Include(g => g.Drzave.OrderByDescending(x=>x.OsvojeniPoeni)).ToListAsync();
        }

        public async Task<List<Grupa>> SearchBy(Expression<Func<Grupa, bool>> predicate)
        {
            return await _context.Grupa.Include(x=>x.Drzave).Where(predicate).ToListAsync();
        }

        public async Task<Grupa> SearchById(object id)
        {
            return await _context.Grupa.FirstAsync(x => x.GrupaId == (int)id);
        }

        public Task<Grupa> Update(Grupa entity)
        {
            throw new NotImplementedException();
        }

        public async Task ZakljucajGrupu(int grupaId)
        {
            var grupa = await SearchById(grupaId);
            grupa.JeZakljucana = true;
            _context.Grupa.Attach(grupa).Property(x => x.JeZakljucana).IsModified = true;

        }
    }
}
