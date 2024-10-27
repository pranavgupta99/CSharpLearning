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
        IEnumerable<City> GetAll();
        City GetByID(int id);
        void Edit(City city);
        void Save(City city);
        void RemoveData(City city);
    }
}
