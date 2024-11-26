using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.DLL.Services
{
    public interface IExamService
    {
        PageResult<ExamViewModel> GetAll(int pageNumber, int pageSize);
        void AddExam(CreateExamsViewModel viewModel);
        IEnumerable<ExamViewModel> GetAllExams();
    }
}
