using CSharpLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Repositories.Interfaces
{
    public interface IStateRepo
    {
        IEnumerable<State> GetAll();
        State GetByID(int id);
        void Save(State state);
        void Edit(State state);
        void RemoveData(State state);
    }
}
