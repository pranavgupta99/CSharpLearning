using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.DLL.Services
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(CreateStudentViewModel vm);
        IEnumerable<StudentsViewModel> GetAll();
        bool SetExamResult(AttendExamViewModel viewModel);
        bool SetGroupIdToStudent(GroupStudentViewModel viewModel);
    }
}
