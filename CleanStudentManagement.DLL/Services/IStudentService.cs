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
        PageResult<StudentViewModel> GetAllStudents(int pageNumber, int pageSize);
        Task<int> AddStudentAsync(CreateStudentViewModel vm);
        IEnumerable<StudentsViewModel> GetAll();
        IEnumerable<ResultViewModel> GetExamResult(int studentId);
        bool SetExamResult(AttendExamViewModel viewModel);
        bool SetGroupIdToStudent(GroupStudentViewModel viewModel);
        StudentProfileViewModel GetStudentById(int studentId);
        void UpdateProfile(StudentProfileViewModel studentProfile);
    }
}
