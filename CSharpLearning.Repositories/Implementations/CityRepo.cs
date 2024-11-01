using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Repositories.Implementations
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;
        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Edit(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            var city = await _context.Cities.Include(x=>x.State).ThenInclude(y=>y.Country).ToListAsync();
            return city;
        }

        public async Task<City> GetByID(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            return city;
        }

        public async Task RemoveData(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task Save(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }
    }
}
