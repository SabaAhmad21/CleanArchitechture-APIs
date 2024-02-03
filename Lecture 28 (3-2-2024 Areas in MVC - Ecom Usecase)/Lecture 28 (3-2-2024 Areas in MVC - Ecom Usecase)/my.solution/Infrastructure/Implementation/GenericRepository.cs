using DbModels;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class GenericRepository : IGenericRepository
    {
        private Evs409Context _context;

        public GenericRepository(Evs409Context context)
        {
            _context = context;
        }
        public async Task<bool> Create(object Entity)
        {
            if (Entity == null) return false;

            var result = await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(object Entity)
        {
            if (Entity != null)
            {
                var result = _context.Update(Entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
