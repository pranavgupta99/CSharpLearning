using CSharpLearning.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Repositories.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T,bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy =null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool dissabledTracking = true);
        Task<T> GetById(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool dissabledTracking = true);
        Task Save(T entity);
        Task Edit(T entity);
        Task RemoveData(T entity);
        void DeleteRange(List<T> entities);
    }
}
