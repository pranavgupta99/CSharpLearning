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
        public void Edit(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            var city = _context.Cities.Include(x=>x.State).ThenInclude(y=>y.Country).ToList();
            return city;
        }

        public City GetByID(int id)
        {
            var city = _context.Cities.Find(id);
            return city;
        }

        public void RemoveData(City city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public void Save(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
    }
}
