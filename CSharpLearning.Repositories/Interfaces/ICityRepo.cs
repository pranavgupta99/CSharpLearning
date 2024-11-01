using CSharpLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Repositories.Interfaces
{
    public interface ICityRepo
    {
        Task<IEnumerable<City>> GetAll();
        Task<City> GetByID(int id);
        Task Edit(City city);
        Task Save(City city);
        Task RemoveData(City city);
    }
}
