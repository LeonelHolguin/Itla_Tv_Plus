using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class SerieRepository
    {
        private readonly ApplicationContext _dbcontext;

        public SerieRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Serie serie)
        {
            await _dbcontext.Series.AddAsync(serie);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Serie serie)
        {
             _dbcontext.Entry(serie).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Serie serie)
        {
            _dbcontext.Set<Serie>().Remove(serie);
            await _dbcontext.SaveChangesAsync();
        } 

        public async Task<List<Serie>> GetAllAsync()
        {
            return await _dbcontext.Set<Serie>()
                .Include(serie => serie.Producer)
                .Include(serie => serie.PrimaryGender)
                .Include(serie => serie.SecondaryGender)
                .ToListAsync();
        }

        public async Task<Serie> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Serie>()
                .Include(serie => serie.Producer)
                .Include(serie => serie.PrimaryGender)
                .Include(serie => serie.SecondaryGender)
                .FirstOrDefaultAsync(serie => serie.SerieId == id);
        }
    }
}
