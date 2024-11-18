using CleanStudentManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T:class;
        void Save();
    }
}
