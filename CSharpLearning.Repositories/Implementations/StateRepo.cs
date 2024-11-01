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
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _context;
        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Edit(State state)
        {
            _context.States.Update(state);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            var states = await _context.States.Include(x=>x.Country).ToListAsync();
            return states;
        }

        public async Task<State> GetByID(int id)
        {
            var state = await _context.States.FindAsync(id);
            return state;
        }

        public async Task RemoveData(State state)
        {
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
        }

        public async Task Save(State state)
        {
            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();
        }
    }
}
