using CSharpLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Repositories.Interfaces
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);
        Task Save(Student student);
        Task Edit(Student student);
        Task RemoveData(Student student);
    }
}
