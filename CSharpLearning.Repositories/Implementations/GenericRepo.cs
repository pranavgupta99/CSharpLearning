using CSharpLearning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Repositories.Implementations
{
    //Attach -- To bring in memory 
    //Detached -- Out of memody that means no operation can be performed
    //Modified --  modify the state
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private ApplicationDbContext _context;
        private DbSet <T> _dbSet;

        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
            _dbSet= _context.Set<T>(); //_context.countries
        }

        public async void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        //_context.slills.Include().toLists();
        public async Task Edit(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool dissabledTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if(dissabledTracking)
            {
                query = query.AsNoTracking();
            }
            if(filter!=null)
            {
                query = query.Where(filter);
            }
            if(include!=null)
            {
                query = include(query);
            }
            if(orderBy!=null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetById(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool dissabledTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (dissabledTracking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task RemoveData(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Save(T entity)
        {
            //_context.Countries.ADD(Country)
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
